using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InstructionDecoder
{
    class CPU
    {
        //attributes here
        private int programCounter;
        const byte INSTRUCTION_SIZE = 2;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CPU()
        {
            programCounter = 0;
        }

        /// <summary>
        /// Decodes the passed instruction
        /// </summary>
        /// <param name="instruction">Int value of instruction (think in terms of bits)</param>
        /// <returns>Formated string of the instruction for output</returns>
        public string DecodeInstruction(int instruction)
        {
            //Note: add private methods that are called from here for decoding,
            // all decoding should originate from this method call
            string strInstruction = "";
            int opcode = instruction & 15;
            switch (opcode)
            {
                case 0:
                    // Halt
                    break;
                case 1:
                    // Load
                    break;
                case 2:
                    // Store
                    break;
                case 3:
                    // Add
                    strInstruction = Add(instruction);
                    break;
                case 4:
                    // Sub
                    break;
                case 5:
                    // Jmp
                    break;
                case 6:
                    // Je
                    break;
                case 7:
                    // Jne
                    break;
                case 8:
                    strInstruction = Increment(instruction);
                    break;
                case 9:
                    // Dec
                    break;
                case 10:
                    // Lsr
                    break;
                case 11:
                    // Lsl
                    break;
                case 12:
                    // Asr
                    break;
                case 13:
                    strInstruction = And(instruction);
                    break;
                case 14:
                    strInstruction = Or(instruction);
                    break;
                case 15:
                    strInstruction = Xor(instruction);
                    break;
                default:
                    break;
            }
            programCounter += INSTRUCTION_SIZE;
            return strInstruction;
        }

        /// <summary>
        /// Retrieves the register in the given instruction and an offset. 
        /// Offset should place desired bits in last nibble of instruction.
        /// </summary>
        /// <param name="instruction">16-bit instruction.</param>
        /// <param name="offset">Number of bits to shift right.</param>
        /// <returns></returns>
        private string getRegister(int instruction, int offset)
        {
            int register = (instruction >> offset) & 15;
            string strRegister = "x" + register.ToString();

            return strRegister;
        }

        #region Opcodes

        /// <summary>
        /// Translates the given increment instruction to a string. 
        /// </summary>
        /// <param name="instruction">16-bit instruction</param>
        /// <returns>String value of given increment instruction.</returns>
        private string Increment(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + "\t";
            strInstruction += "08\t";
            strInstruction += "INC\t";
            strInstruction += getRegister(instruction, 4);

            return strInstruction;
        }

        /// <summary>
        /// Translates the given AND instruction to a string. 
        /// </summary>
        /// <param name="instruction">16-bit instruction.</param>
        /// <returns>String value of given AND instruction.</returns>
        private string And(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + "\t";
            strInstruction += "0D\t";
            strInstruction += "AND\t";
            strInstruction += getRegister(instruction, 4) + ",";
            strInstruction += getRegister(instruction, 8) + ",";
            strInstruction += getRegister(instruction, 12);

            return strInstruction;
        }

        /// <summary>
        /// Translates the given OR instruction to a string.
        /// </summary>
        /// <param name="instruction">16-bit instruction.</param>
        /// <returns>String value of given OR instruction.</returns>
        private string Or(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + "\t";
            strInstruction += "0E\t";
            strInstruction += "OR\t";
            strInstruction += getRegister(instruction, 4) + ",";
            strInstruction += getRegister(instruction, 8) + ",";
            strInstruction += getRegister(instruction, 12);

            return strInstruction;
        }

        /// <summary>
        /// Translates the given XOR instruction to a string. 
        /// </summary>
        /// <param name="instruction">16-bit instruction.</param>
        /// <returns>String value of given XOR instruction.</returns>
        private string Xor(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + "\t";
            strInstruction += "0F\t";
            strInstruction += "XOR\t";
            strInstruction += getRegister(instruction, 4) + ",";
            strInstruction += getRegister(instruction, 8) + ",";
            strInstruction += getRegister(instruction, 12);

            return strInstruction;
        }

        private string Add(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + ",";
            strInstruction += "03,";
            strInstruction += "ADD,";
            strInstruction += getRegister(instruction, 4) + ",";
            strInstruction += getRegister(instruction, 8) + ",";
            strInstruction += getRegister(instruction, 12);

            return strInstruction;
        }

        #endregion
    }
}
