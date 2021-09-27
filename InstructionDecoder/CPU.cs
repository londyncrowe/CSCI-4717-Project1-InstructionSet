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
                    // And
                    break;
                case 14:
                    // Or
                    break;
                case 15:
                    // Xor
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
            string strRegister = string.Empty;
            int register = (instruction >> offset) & 15;
            switch (register)
            {
                case 0:
                    strRegister = "x0";
                    break;
                case 1:
                    strRegister = "x1";
                    break;
                case 2:
                    strRegister = "x2";
                    break;
                case 3:
                    strRegister = "x3";
                    break;
                case 4:
                    strRegister = "x4";
                    break;
                case 5:
                    strRegister = "x5";
                    break;
                case 6:
                    strRegister = "x6";
                    break;
                case 7:
                    strRegister = "x7";
                    break;
                case 8:
                    strRegister = "x8";
                    break;
                case 9:
                    strRegister = "x9";
                    break;
                case 10:
                    strRegister = "x10";
                    break;
                case 11:
                    strRegister = "x11";
                    break;
                case 12:
                    strRegister = "x12";
                    break;
                case 13:
                    strRegister = "x13";
                    break;
                case 14:
                    strRegister = "x14";
                    break;
                case 15:
                    strRegister = "x15";
                    break;
                default:
                    break;
            }

            return strRegister;
        }

        /// <summary>
        /// Translates the given 16-bit instruction to a string. 
        /// </summary>
        /// <param name="instruction">16-bit instruction</param>
        /// <returns>String value of given instruction.</returns>
        private string Increment(int instruction)
        {
            string strInstruction = programCounter.ToString("0000") + "\t";
            strInstruction += "08\t";
            strInstruction += "INC\t";
            strInstruction += getRegister(instruction, 4);

            return strInstruction;
        }
    }
}
