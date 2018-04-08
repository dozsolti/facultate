let nn;

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
        console.log("gata trainingul.");
        let mNr=0,mPas=0;
        for (let i = 0; i < 2000000; i++) {
                let nr = Math.round(random(500000000000000 , 1000000000000000));
                let x = decPasi(nn.predict([encInput(nr)]),nr);
                if(x>mPas){
                        mPas = x;
                        mNr=nr;
                        console.log("Noul max este : ",nr,x);
                }
        }
        console.log("gata cautarea.");
        //compare(950435459434052.2);
}
function compare(nr =0){
        if(nr==0)
                nr = Math.round(random(500000000000000 , 1000000000000000));
        let guess = decPasi(nn.predict( [encInput(nr)] ),nr);
        console.log(nr,getNrPasi(nr),guess);
}
function getNrPasi(n)
{
        let i=n;
        let p=0;
        do{
                p++;
                if(n%2==0)
                        n = n/2;
                else
                        n=n*3+1;
        }while(n!=1);
        if(p>=1810)
                console.log("L-am gasit: ",i);
        return p;
}

function encInput(inp){
        return (inp - 500000000000000)/499999999999999;
}
function decInput(val){
        return (val*499999999999999)+500000000000000;
}
function encPasi(val,nr){
        return val/getNrPasi(nr);
}
function decPasi(val,nr){
        return val*getNrPasi(nr);
}