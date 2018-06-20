let model;
let statusP;
let maxNr,maxPasi ;
let sum, count;
let training=false;
function setup() {

  model = tf.sequential();
  const hiddenLayer = tf.layers.dense({
    units: 4,
    inputShape: [1],
    activation: 'sigmoid'
  });
  const outputLayer = tf.layers.dense({
    units: 1,
    activation: 'sigmoid'
  });
  model.add(hiddenLayer);
  model.add(outputLayer);

  const optimizer = tf.train.adam(0.01);

  model.compile({
    optimizer: optimizer,
    // optimizer: 'sgd',
    loss: 'meanSquaredError'
  });
  statusP = createP('0');
  maxPasi=-1;
  maxNr = -1;
  sum=0;
  count=0;
  train();
}
function finished() {
  count++;
  let nr = decInput(model.predict(tf.tensor2d([[1]])).dataSync()[0]);
  let pasi = getNrPasi(nr);
  sum += pasi;
  if(maxPasi<pasi){
    maxNr = nr;
    maxPasi = pasi;
  }
  statusP.html(`<h1>${maxNr} : ${maxPasi}<br>Avg: ${sum/count}</h1>`);
  training = false;
  
  // We need to let the JavaScript event loop tick forward before we call `train()`.
  setTimeout(train, 0);
}
function train() {
  if (!training) {
    training = true;
    trainModel().then(finished);
  }
}
async function trainModel() {
  let inputs = [];
  let outputs = [];
  for (let i = 0; i < 200; i++) {
    let nr = Math.round(random(500000000000000, 1000000000000000));
    inputs.push([encInput(nr)]);
    outputs.push([encPasi(getNrPasi(nr))]);
  }
  return await model.fit(tf.tensor2d(outputs), tf.tensor2d(inputs), {
    epochs: 5,
    shuffle:true
  });
}

function compare(nr = 0) {
  if (nr == 0)
    nr = Math.round(random(500000000000000, 1000000000000000));
    
  let correct = getNrPasi(nr);

  let y = model.predict(tf.tensor2d([
    [encPasi(correct)]
  ]));
  let guess = floor(decInput(y.dataSync()[0]));
  y.dispose();


  return (nr + "<br>" + guess);

}

function getNrPasi(n) {
  let i = n;
  let p = 0;
  do {
    p++;
    if (n % 2 == 0)
      n = n / 2;
    else
      n = n * 3 + 1;
  } while (n != 1);
  if (p >= 1810)
    console.log("L-am gasit: ", i);
  return p;
}


//din numar la [0,1]
function encInput(val) {
  return map(val, 500000000000000, 999999999999999, 0, 1);
}

//din [0,1] la numar
function decInput(val) {
  return map(val, 0, 1, 500000000000000, 999999999999999);
}

function encPasi(val) {
  return map(val, 0, 1820, 0, 1);
}

function decPasi(val) {
  return map(val, 0, 1, 0, 1820);
}