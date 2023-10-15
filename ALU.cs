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

        public string eightBitAdd(string[] inputs){
            string[] Output = new string[9]; //set output list
            string[] StringL1 = inputs[0].ToCharArray().Select(c => c.ToString()).ToArray(); //these two split inputs into individual bits
            string[] StringL2 = inputs[1].ToCharArray().Select(c => c.ToString()).ToArray();
            string[] Inputs = new string[] {StringL1[4] + StringL1[5] + StringL1[6] + StringL1[7], StringL2[4] + StringL2[5] + StringL2[6] + StringL2[7], inputs[2]}; //set first 1 but adder inputs to array
            string ResultBit1 = fourBitAdd(Inputs); //do the first calculation
            char[] CarryBitArr = ResultBit1.ToCharArray(); //set that to an array to allow for the carry bit to be abtained
            char CarryBit = CarryBitArr[0]; //get the carry bit
            Inputs = new string[] {StringL1[0] + StringL1[1] + StringL1[2] + StringL1[3], StringL2[0] + StringL2[1] + StringL2[2] + StringL2[3], CarryBit.ToString()}; //set new inputs with thte newly gained carry bit
            string ResultBit2 = fourBitAdd(Inputs); //get new outputs
            string[] OABitArr = ResultBit1.ToCharArray().Select(c => c.ToString()).ToArray(); //take the results and take to individual values 
            string[] OBCBitArr = ResultBit2.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[8] = OABitArr[4];//set all the outputes in the correct order of bits 
            Output[7] = OABitArr[3];
            Output[6] = OABitArr[2];
            Output[5] = OABitArr[1];
            Output[4] = OBCBitArr[4];
            Output[3] = OBCBitArr[3];
            Output[2] = OBCBitArr[2];
            Output[1] = OBCBitArr[1];
            Output[0] = OBCBitArr[0];
            return String.Join("", Output);//return value
        }

        public string oneBitSubtractor(int[] inputs){
            int A0 = inputs[2];//setup 3 values
            int A1 = inputs[1];
            int Carry = inputs[0];
            string[] Output = new string[2]; //setup output string
            int XOR1 = logicGates.XOR(A0, A1); //setup first XOR that will be used more than once
            Output[1] = logicGates.XOR(XOR1, Carry).ToString();//set output 1
            Output[0] = logicGates.OR(logicGates.AND(Carry, logicGates.NOT(XOR1)), logicGates.AND(A1, logicGates.NOT(A0))).ToString();//set output 2
            return string.Join("", Output);
        }

        public string eightBitSubtractor(string[] inputs){
            string[] byte1 = inputs[0].ToCharArray().Select(c => c.ToString()).ToArray();//setup byte 1
            string[] byte2 = inputs[1].ToCharArray().Select(c => c.ToString()).ToArray();//setup byte 2
            string[] Output = new string[8];//setup output
            
            //least significant bit aka the end bit
            int[] intInputs = new int[] {0, int.Parse(byte2[7]), int.Parse(byte1[7])};//set inputs
            string Outs = oneBitSubtractor(intInputs);//calc
            string[] OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();//set output arr
            Output[7] = OutsArr[1];//select output for the output bit
            string Carry = OutsArr[0];//select carry bit
            //the same for the rest of them but different bits

            //7th bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[6]), int.Parse(byte1[6])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[6] = OutsArr[1];
            Carry = OutsArr[0];

            //6th bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[5]), int.Parse(byte1[5])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[5] = OutsArr[1];
            Carry = OutsArr[0];

            //5th bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[4]), int.Parse(byte1[4])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[4] = OutsArr[1];
            Carry = OutsArr[0];

            //4th bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[3]), int.Parse(byte1[3])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[3] = OutsArr[1];
            Carry = OutsArr[0];

            //3rd bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[2]), int.Parse(byte1[2])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[2] = OutsArr[1];
            Carry = OutsArr[0];


            //2nd bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[1]), int.Parse(byte1[1])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[1] = OutsArr[1];
            Carry = OutsArr[0];

            //1st bit
            intInputs = new int[] {int.Parse(Carry), int.Parse(byte2[0]), int.Parse(byte1[0])};
            Outs = oneBitSubtractor(intInputs);
            OutsArr = Outs.ToCharArray().Select(c => c.ToString()).ToArray();
            Output[0] = OutsArr[1];
            return string.Join("", Output);//return the output
        }

        public string LeftShift(string Byte){
            return "";
        }

        public string RightShift(){
            return "";
        }
    }
}