using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InstructionDecoder
{
    class CPU
    {
        //attributes here

        /// <summary>
        /// Default constructor
        /// </summary>
        public CPU()
        {
            
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
                    // Inc
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

            return strInstruction;
        }

    }
}
