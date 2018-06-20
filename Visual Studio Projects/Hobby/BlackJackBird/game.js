function mutate(x) {
        if (random(1) < 0.1) {
                let offset = randomGaussian() * 0.5;
                let newx = x + offset;
                return newx;
        } else {
                return x;
        }
}

class Game {
        constructor(brain) {
                this.deckIndex = 0;
                this.deck = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10];
                for (let i = this.deck.length - 1; i >= 0; i--) {
                        let j = int(random(i));
                        let temp = this.deck[i];
                        this.deck[i] = this.deck[j];
                        this.deck[j] = temp;
                }

                this.enemy = [];
                this.enemy.push(this.deck[this.deckIndex]);
                this.deckIndex++;

                this.my = [];
                this.my.push(this.deck[this.deckIndex]);
                this.deckIndex++;
                this.my.push(this.deck[this.deckIndex]);
                this.deckIndex++;

                this.fitness = 0;
                this.standed = false;

                if (brain instanceof NeuralNetwork) {
                        this.brain = brain.copy();
                        this.brain.mutate(mutate);
                } else {
                        this.brain = new NeuralNetwork(3, 18, 2);
                }
        }
        copy() {
                return new Game(this.brain);
        }
        think() {

                let inputs = [];
                inputs[0] = this.enemy[0];
                inputs[1] = this.my[0];
                inputs[2] = this.my[1];
                let action = this.brain.predict(inputs);
                if (action[1] > action[0]) {
                        this.hit();
                } else {
                        this.stand();
                }
        }
        hit() {
                this.my.push(this.deck[this.deckIndex]);
                this.deckIndex++;
                if (this.SumMyCards() > 21) {
                        this.fitness = 0;
                        return;
                }
                this.stand();
                
        }

        stand() {
                this.standed = true;
                while (this.SumEnemyCards() < 17) {
                        this.enemy.push(this.deck[this.deckIndex]);
                        this.deckIndex++;
                }
                this.calcFitness();
        }
        toDestroy() {
                if (this.SumMyCards() > 21 || this.SumEnemyCards() > 21 || this.standed)
                        return true;
                return false;
        }

        calcFitness() {
                if (this.SumEnemyCards() > 21) {
                        this.fitness = 1;
                        return;
                }

                if (this.SumEnemyCards() == 21) {
                        if (this.SumMyCards() == 21)
                                this.fitness = 0.75;
                        else
                                this.fitness = 0;
                        return;
                }
                if (this.SumMyCards() == 21)
                        this.fitness = 1;

                if (this.SumEnemyCards() > this.SumMyCards())
                        this.fitness = 0.25;
                else
                        this.fitness = 1;
        }

        SumMyCards() {
                return this.my.reduce(function (acc, val) {
                        return acc + val;
                });
        }
        SumEnemyCards() {
                return this.enemy.reduce(function (acc, val) {
                        return acc + val;
                });
        }
}