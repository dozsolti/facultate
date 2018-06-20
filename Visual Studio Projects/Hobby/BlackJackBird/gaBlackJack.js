// Daniel Shiffman
// Nature of Code: Intelligence and Learning
// https://github.com/shiffman/NOC-S17-2-Intelligence-Learning

// This flappy bird implementation is adapted from:
// https://youtu.be/cXgA1d_E-jY&


// This file includes functions for creating a new generation
// of birds.


// Create the next generation
function nextGeneration() {
  // Generate a new set of birds
  
  activeGames = generate(allGames);
  // Copy those birds to another array
  allGames = activeGames.slice();
}

// Generate a new population of birds
function generate(oldGames) {
  let newGames = [];
  let k=10;

  oldGames.sort((a,b)=>b.fitness-a.fitness);
  for (let i = 0; i < k; i++) 
    newGames[i] = oldGames[i];

  for (let i = 0; i < oldGames.length-k; i++) {
    // Select a bird based on fitness
    let bird = poolSelection(oldGames);
    newGames[i+k] = bird;
  }
  return newGames;
}



// An algorithm for picking one bird from an array
// based on fitness
function poolSelection(birds) {
  // Start at 0
  let index = 0;

  // Pick a random number between 0 and 1
  let r = random(1);

  // Keep subtracting probabilities until you get less than zero
  // Higher probabilities will be more likely to be fixed since they will
  // subtract a larger number towards zero
  while (r > 0) {
    r -= birds[index].fitness;
    // And move on to the next
    index += 1;
  }

  // Go back one
  index -= 1;

  // Make sure it's a copy!
  // (this includes mutation)
  return birds[index].copy();
}