using System.Threading.Channels;

LogicMain.Execution execution = new LogicMain.Execution();

execution.Main();
namespace LogicMain{

    public class LogicGates {
        public int AND(int A, int B){
            if(A == 1 && B == 1){
                return 1;
            }
            else{
                return 0;
            }
        }

        public int OR(int A, int B){
            if(A != B){
                return 1;
            }
            else{
                return AND(A, B);
            }
        }

        public int NOT(int A){
            if(A == 0){
                return 1;
            }
            else{
                return 0;
            }
        }

        public int NAND(int A, int B){
            if(A == 1 && B == 1){
                return 0;
            }
            else{
                return 1;
            }
        }

        public int NOR(int A, int B){
            return NOT(OR(A, B));
        }

        public int XOR(int A, int B){
            return AND(OR(A, B), NAND(A, B));
        }

        public int XNOR(int A, int B){
            return NOT(XOR(A, B));
        }
        
        

    }

    class Execution{
        LogicMain.ALU alu = new LogicMain.ALU();
        LogicGates logicGates = new LogicGates();
        public void Main(){
            string[] input = new string[] {"11111111", "11111111", "1"};
            Console.WriteLine(alu.eightBitAdd(input)); //110101101
        }
    }
}
