// Daniel Shiffman
// Nature of Code: Intelligence and Learning
// https://github.com/shiffman/NOC-S18

// This flappy bird implementation is adapted from:
// https://youtu.be/cXgA1d_E-jY&

// How big is the population
let totalPopulation = 5;
// All active birds (not yet collided with pipe)
let activeBirds = [];
let activeGames = [];
// All birds for any given population
let allBirds = [];
// Pipes
let pipes = [];
// A frame counter to determine when to add a pipe
let counter = 0;

// Interface elements
let speedSlider;
let speedSpan;





function setup() {
  let canvas = createCanvas(600, 400);
  canvas.parent('canvascontainer');

  // Access the interface elements
  speedSlider = select('#speedSlider');
  speedSpan = select('#speed');

  // Create a population
  for (let i = 0; i < totalPopulation; i++) {
    let bird = new Bird();
    activeBirds[i] = bird;
    allBirds[i] = bird;
  }
  for (let i = 0; i < totalPopulation; i++) {
    let game = new Game();
    activeGames[i] = game;
  }
  console.log(activeGames);
}



function draw() {
  background(0);

  // Should we speed up cycles per frame
  let cycles = speedSlider.value();
  speedSpan.html(cycles);


  // How many times to advance the game
  for (let n = 0; n < cycles; n++) {
    // Show all the pipes
    for (let i = pipes.length - 1; i >= 0; i--) {
      pipes[i].update();
      if (pipes[i].offscreen()) {
        pipes.splice(i, 1);
      }
    }

    for (let i = activeBirds.length - 1; i >= 0; i--) {
      let bird = activeBirds[i];
      // Bird uses its brain!
      bird.think(pipes);
      bird.update();

      // Check all the pipes
      for (let j = 0; j < pipes.length; j++) {
        // It's hit a pipe
        if (pipes[j].hits(activeBirds[i])) {
          // Remove this bird
          activeBirds.splice(i, 1);
          break;
        }
      }

      if (bird.bottomTop()) {
        activeBirds.splice(i, 1);
      }

    }


    // Add a new pipe every so often
    if (counter % 75 == 0) {
      pipes.push(new Pipe());
    }
    counter++;
  }

  // Draw everything!
  for (let i = 0; i < pipes.length; i++) {
    pipes[i].show();
  }

  for (let i = 0; i < activeBirds.length; i++) {
    activeBirds[i].show();
  }
  // If we're out of birds go to the next generation
  if (activeBirds.length == 0) {
    nextGeneration();
  }
}