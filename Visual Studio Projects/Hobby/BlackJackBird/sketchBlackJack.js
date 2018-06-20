// Daniel Shiffman
// Nature of Code: Intelligence and Learning
// https://github.com/shiffman/NOC-S18

// This flappy bird implementation is adapted from:
// https://youtu.be/cXgA1d_E-jY&

// How big is the population
let totalPopulation = 500;
// All active birds (not yet collided with pipe)
let allGames = [];
let activeGames = [];

// Interface elements
let speedSlider;
let speedSpan;



function setup() {
  let canvas = createCanvas(600, 400);
  canvas.parent('canvascontainer');

  // Access the interface elements
  speedSlider = select('#speedSlider');
  speedSpan = select('#speed');


  for (let i = 0; i < totalPopulation; i++) {
    let game = new Game();
    activeGames[i] = game;
    allGames[i] = game;
  }
}

function draw() {
  background(0);

  // Should we speed up cycles per frame
  let cycles = speedSlider.value();
  speedSpan.html(cycles);


  // How many times to advance the game
  for (let n = 0; n < cycles; n++) {
    // Show all the pipes
    for (let i = activeGames.length - 1; i >= 0; i--) {
      let game = activeGames[i];
      game.think();
      if (game.toDestroy())
        activeGames.splice(i, 1);
    }

  }
  textSize(32);
  fill(255);

  let count = 0;
  for(let i =0 ;i<allGames.length;i++)
    if(allGames[i].fitness==1)
      count++;
  
  text(count/allGames.length, 10, 30);

  if (activeGames.length === 0) {
    nextGeneration();
  }
}