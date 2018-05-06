let nn;
let i = 0;

function setup() {
        nn = new NeuralNetwork(1, 2, 1);

        /*for (let i = 0; i < 60000000; i++) {

                let rnd = random(500000000000000 , 1000000000000000);

                let data = [
                        encInput(rnd),
                        encPasi(getNrPasi(rnd),rnd)
                ]; 
                nn.train([data[0]], [data[1]]);
        }*/
         

        //compare(950435459434052.2);revPredict(361.9396583426855);
        let result = reverseSigmoid(0.9998335993970772);
        result -= 3.043032028650123;
        console.log("RevSigmoid-3.04 = ", result);
        console.log(result==5.6579139631501985);
}

function revPredict(nrPasi=0.9940552383869377) {
        //pasii
        //nrPasi = 0.999833590793533;
        let result = reverseSigmoid(nrPasi);
        result -= 3.043032028650123;
        console.log("RevSigmoid-3.04 = ", result);
        //hidden
        let valoarePrimitaDeLaRemus = 0.9999972423913958;
        let ha = reverseSigmoid(valoarePrimitaDeLaRemus);
        ha -= 7.86057963752604;
        //ha = 4.940564306380421;
        console.log("ha-7.86= ",ha);
        //numarul
        let n = ha/2.4702821531902077;
        
        console.log("Numarul este ",n);
        //n = decInput(n);
        return n;
}
function siig(x){
        return 1 / (1 + Math.exp(-x));
}
function reverseSigmoid(x){
        return Math.abs(Math.log(1-x));
}
function compare(nr = 0) {
        if (nr == 0)
                nr = Math.round(random(500000000000000, 1000000000000000));
        let guess = decPasi(nn.predict([encInput(nr)]), nr);
        console.log(nr, getNrPasi(nr), guess);
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

function encInput(inp) {
        return (inp) / 499999999999999;
}

function decInput(val) {
        return (val * 499999999999999) + 500000000000000;
}

function encPasi(val, nr) {
        return val / nr;
}

function decPasi(val, nr) {
        return val * getNrPasi(nr);
}