// Prototype only — throwaway web build for Hạt Mầm Vàng core loop.
// Same question as the Unity prototype, translated to Babylon.js:
// plow -> sow -> water -> harvest -> process -> sell.
// No build step: open index.html in a browser (internet needed for the
// Babylon.js CDN script). No menus, save, music, villagers, seasons,
// green balance, livestock or land planning in this prototype.

(function () {
  "use strict";

  var canvas = document.getElementById("renderCanvas");
  var engine = new BABYLON.Engine(canvas, true);
  var scene = new BABYLON.Scene(engine);

  // Camera: fixed-angle follow camera, same framing as the Unity prototype.
  var camera = new BABYLON.UniversalCamera("camera", new BABYLON.Vector3(0, 10, -17), scene);
  camera.setTarget(new BABYLON.Vector3(0, 1, -8));

  new BABYLON.HemisphericLight("hemi", new BABYLON.Vector3(0, 1, 0), scene);
  var sun = new BABYLON.DirectionalLight("sun", new BABYLON.Vector3(-0.5, -1, -0.5), scene);
  sun.position = new BABYLON.Vector3(10, 20, 10);

  function material(name, r, g, b) {
    var m = new BABYLON.StandardMaterial(name, scene);
    m.diffuseColor = new BABYLON.Color3(r, g, b);
    return m;
  }

  // Ground.
  var ground = BABYLON.MeshBuilder.CreateGround("ground", { width: 30, height: 30 }, scene);
  ground.material = material("groundMat", 0.3, 0.6, 0.3);

  // Player: capsule, starts south of the plots so plots are in front.
  var player = BABYLON.MeshBuilder.CreateCapsule("player", { height: 2, radius: 0.5 }, scene);
  player.position = new BABYLON.Vector3(0, 1, -8);
  player.material = material("playerMat", 0.8, 0.8, 0.8);

  // Inventory.
  var inv = { seeds: 20, crops: 0, processed: 0, coins: 0 };
  var statusEl = document.getElementById("status");
  var promptEl = document.getElementById("prompt");

  function updateUI() {
    statusEl.textContent =
      "Hat giong: " + inv.seeds + "\n" +
      "Lua: " + inv.crops + "\n" +
      "Gao: " + inv.processed + "\n" +
      "Xu: " + inv.coins + "\n" +
      "WASD di chuyen - E tuong tac";
  }

  // Plots: 4x4, states Untilled -> Tilled -> PlantedDry -> Growing -> Ready.
  var plots = [];
  for (var x = 0; x < 4; x++) {
    for (var z = 0; z < 4; z++) {
      var px = (x - 1.5) * 1.5;
      var pz = (z - 1.5) * 1.5 - 2;
      var plotMesh = BABYLON.MeshBuilder.CreateBox("plot_" + x + "_" + z,
        { width: 1.2, height: 0.2, depth: 1.2 }, scene);
      plotMesh.position = new BABYLON.Vector3(px, 0.1, pz);
      var plotMat = material("plotMat_" + x + "_" + z, 0.35, 0.25, 0.15);
      plotMesh.material = plotMat;

      var plant = BABYLON.MeshBuilder.CreateBox("plant_" + x + "_" + z,
        { width: 0.3, height: 0.3, depth: 0.3 }, scene);
      plant.position = new BABYLON.Vector3(px, 0.4, pz);
      var plantMat = material("plantMat_" + x + "_" + z, 0, 0.7, 0);
      plant.material = plantMat;
      plant.isVisible = false;

      plots.push({
        mesh: plotMesh, plant: plant, plotMat: plotMat, plantMat: plantMat,
        state: "Untilled", timer: 0
      });
    }
  }

  function plotPrompt(plot) {
    if (plot.state === "Untilled") return "Cuoc dat";
    if (plot.state === "Tilled") return "Gieo hat (1 hat giong)";
    if (plot.state === "PlantedDry") return "Tuoi nuoc";
    if (plot.state === "Growing") return "Dang lon...";
    if (plot.state === "Ready") return "Thu hoach lua";
    return "";
  }

  function updatePlotVisual(plot) {
    if (plot.state === "Untilled") {
      plot.plotMat.diffuseColor = new BABYLON.Color3(0.35, 0.25, 0.15);
      plot.plant.isVisible = false;
    } else {
      plot.plotMat.diffuseColor = new BABYLON.Color3(0.55, 0.38, 0.2);
      if (plot.state === "Tilled") {
        plot.plant.isVisible = false;
      } else if (plot.state === "PlantedDry") {
        plot.plant.isVisible = true;
        plot.plant.scaling = new BABYLON.Vector3(0.7, 0.7, 0.7);
        plot.plantMat.diffuseColor = new BABYLON.Color3(0, 0.7, 0);
      } else if (plot.state === "Growing") {
        plot.plant.isVisible = true;
        plot.plantMat.diffuseColor = new BABYLON.Color3(0, 0.7, 0);
      } else if (plot.state === "Ready") {
        plot.plant.isVisible = true;
        plot.plant.scaling = new BABYLON.Vector3(2.5, 4, 2.5);
        plot.plantMat.diffuseColor = new BABYLON.Color3(1, 0.85, 0);
      }
    }
  }

  function interactPlot(plot) {
    if (plot.state === "Untilled") {
      plot.state = "Tilled";
    } else if (plot.state === "Tilled") {
      if (inv.seeds <= 0) { promptEl.textContent = "Het hat giong!"; return; }
      inv.seeds -= 1;
      plot.state = "PlantedDry";
    } else if (plot.state === "PlantedDry") {
      plot.state = "Growing";
      plot.timer = 0;
    } else if (plot.state === "Ready") {
      inv.crops += 2;
      plot.state = "Untilled";
    }
    updatePlotVisual(plot);
    updateUI();
  }

  // Stations: processing (yellow, right) and market (blue, left).
  var processing = { processing: false, timer: 0 };
  function makeStation(name, x, color) {
    var mesh = BABYLON.MeshBuilder.CreateBox(name, { width: 2, height: 2, depth: 2 }, scene);
    mesh.position = new BABYLON.Vector3(x, 1, 0);
    mesh.material = material(name + "Mat", color[0], color[1], color[2]);
    return mesh;
  }
  var processingMesh = makeStation("processingStation", 6, [1, 0.85, 0]);
  var marketMesh = makeStation("marketStall", -6, [0.2, 0.4, 1]);

  function interactStation(kind) {
    if (kind === "processing") {
      if (processing.processing) return;
      if (inv.crops < 3) { promptEl.textContent = "Can 3 lua de che bien!"; return; }
      inv.crops -= 3;
      processing.processing = true;
      processing.timer = 0;
    } else {
      if (inv.processed <= 0) { promptEl.textContent = "Chua co gao de ban!"; return; }
      inv.processed -= 1;
      inv.coins += 10;
    }
    updateUI();
  }

  // Input: WASD + arrows move, E interacts with the nearest thing in range.
  var keys = {};
  window.addEventListener("keydown", function (e) {
    keys[e.key.toLowerCase()] = true;
    if ((e.key === "e" || e.key === "E") && !e.repeat) {
      var target = findNearest();
      if (target) target.interact();
    }
  });
  window.addEventListener("keyup", function (e) {
    keys[e.key.toLowerCase()] = false;
  });

  function findNearest() {
    var best = null;
    var bestDist = 3.5;
    function consider(pos, prompt, interact) {
      var d = BABYLON.Vector3.Distance(player.position, pos);
      if (d < bestDist) { bestDist = d; best = { prompt: prompt, interact: interact }; }
    }
    plots.forEach(function (plot) {
      consider(plot.mesh.position, plotPrompt(plot), function () { interactPlot(plot); });
    });
    consider(processingMesh.position,
      processing.processing ? "Dang che bien..." : "Che bien (3 lua -> 1 gao)",
      function () { interactStation("processing"); });
    consider(marketMesh.position, "Ban gao (1 gao -> 10 xu)",
      function () { interactStation("market"); });
    return best;
  }

  updateUI();

  engine.runRenderLoop(function () {
    var dt = engine.getDeltaTime() / 1000;

    // Movement.
    var mx = 0, mz = 0;
    if (keys["w"] || keys["arrowup"]) mz += 1;
    if (keys["s"] || keys["arrowdown"]) mz -= 1;
    if (keys["a"] || keys["arrowleft"]) mx -= 1;
    if (keys["d"] || keys["arrowright"]) mx += 1;
    if (mx !== 0 || mz !== 0) {
      var len = Math.sqrt(mx * mx + mz * mz);
      var speed = 6 * dt;
      player.position.x += (mx / len) * speed;
      player.position.z += (mz / len) * speed;
      player.rotation.y = Math.atan2(mx, mz);
    }

    // Camera follows the player from behind.
    camera.position = new BABYLON.Vector3(
      player.position.x, player.position.y + 9, player.position.z - 9);
    camera.setTarget(player.position.clone().add(new BABYLON.Vector3(0, 1, 0)));

    // Growth (8 seconds) and processing (3 seconds).
    plots.forEach(function (plot) {
      if (plot.state !== "Growing") return;
      plot.timer += dt;
      var progress = Math.min(plot.timer / 8, 1);
      plot.plant.scaling = new BABYLON.Vector3(
        0.7 + progress * 1.8, 0.7 + progress * 3.3, 0.7 + progress * 1.8);
      if (plot.timer >= 8) {
        plot.state = "Ready";
        updatePlotVisual(plot);
      }
    });
    if (processing.processing) {
      processing.timer += dt;
      if (processing.timer >= 3) {
        processing.processing = false;
        inv.processed += 1;
        updateUI();
      }
    }

    // Prompt for the nearest interactable.
    var nearest = findNearest();
    promptEl.textContent = nearest ? "E: " + nearest.prompt : "";

    scene.render();
  });

  window.addEventListener("resize", function () { engine.resize(); });
})();
