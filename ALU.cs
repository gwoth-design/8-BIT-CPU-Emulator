using LogicMain;



namespace LogicMain
{
    class ALU
    {
        LogicMain.LogicGates logicGates = new LogicMain.LogicGates();
        public string oneBitAdd(int[] inputs)
        {
            int[] Output = new int[2]; //setup output array
            Output[1] = logicGates.XOR(inputs[2], logicGates.XOR(inputs[0], inputs[1])); //do the fist calculation for the first output bit
            Output[0] = logicGates.OR(logicGates.AND(inputs[0], inputs[1]), logicGates.AND(inputs[2], logicGates.XOR(inputs[0], inputs[1]))); //do the secojnd calculation for the second bit
            string joinedResult = string.Join("", Output);//join the two outputs into a new string 
            return joinedResult; //return
        }

        public string twoBitAdd(string[] inputs)
        {
            string[] Output = new string[3]; //set output list
            string[] StringL1 = inputs[0].ToCharArray().Select(c => c.ToString()).ToArray(); //these two split inputs into individual bits
            string[] StringL2 = inputs[1].ToCharArray().Select(c => c.ToString()).ToArray();
            int[] Inputs = new int[] {int.Parse(StringL1[1]), int.Parse(StringL2[1]), int.Parse(inputs[2])}; //set first 1 but adder inputs to array
            string ResultBit1 = oneBitAdd(Inputs); //do the first calculation
            char[] CarryBitArr = ResultBit1.ToCharArray(); //set that to an array to allow for the carry bit to be abtained
            char CarryBit = CarryBitArr[0]; //get the carry bit
            Inputs = new int[] {int.Parse(StringL1[0]), int.Parse(StringL2[0]), int.Parse(CarryBit.ToString())}; //set new inputs with thte newly gained carry bit
            string ResultBit2 = oneBitAdd(Inputs); //get new outputs
            string[] OABitArr = ResultBit1.ToCharArray().Select(c => c.ToString()).ToArray(); //take the results and take to individual values 
            string OABit = OABitArr[1];
            string[] OBCBitArr = ResultBit2.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[2] = OABit;//set all the outputes in the correct order of bits 
            Output[1] = OBCBitArr[1];
            Output[0] = OBCBitArr[0];
            return String.Join("", Output);//return value
        }
        
        public string fourBitAdd(string[] inputs){
            string[] Output = new string[5]; //set output list
            string[] StringL1 = inputs[0].ToCharArray().Select(c => c.ToString()).ToArray(); //these two split inputs into individual bits
            string[] StringL2 = inputs[1].ToCharArray().Select(c => c.ToString()).ToArray();
            string[] Inputs = new string[] {StringL1[2] + StringL1[3], StringL2[2] + StringL2[3], inputs[2]}; //set first 1 but adder inputs to array
            string ResultBit1 = twoBitAdd(Inputs); //do the first calculation
            char[] CarryBitArr = ResultBit1.ToCharArray(); //set that to an array to allow for the carry bit to be abtained
            char CarryBit = CarryBitArr[0]; //get the carry bit
            Inputs = new string[] {StringL1[0] + StringL1[1], StringL2[0] + StringL2[1], CarryBit.ToString()}; //set new inputs with thte newly gained carry bit
            string ResultBit2 = twoBitAdd(Inputs); //get new outputs
            string[] OABitArr = ResultBit1.ToCharArray().Select(c => c.ToString()).ToArray(); //take the results and take to individual values 
            string[] OBCBitArr = ResultBit2.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[4] = OABitArr[2];//set all the outputes in the correct order of bits 
            Output[3] = OABitArr[1];
            Output[2] = OBCBitArr[2];
            Output[1] = OBCBitArr[1];
            Output[0] = OBCBitArr[0];
            return String.Join("", Output);//return value
        }

        public string eightBitAdd(){
            return "";
        }

        public string LeftShift(){
            return "";
        }

        public string RightShift(){
            return "";
        }
    }
}