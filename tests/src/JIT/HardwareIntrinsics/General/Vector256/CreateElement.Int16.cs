// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\General\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace JIT.HardwareIntrinsics.General
{
    public static partial class Program
    {
        private static void CreateElementInt16()
        {
            var test = new VectorCreate__CreateElementInt16();

            // Validates basic functionality works
            test.RunBasicScenario();

            // Validates calling via reflection works
            test.RunReflectionScenario();

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class VectorCreate__CreateElementInt16
    {
        private static readonly int LargestVectorSize = 32;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector256<Int16>>() / sizeof(Int16);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            Int16[] values = new Int16[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetInt16();
            }

            Vector256<Int16> result = Vector256.Create(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11], values[12], values[13], values[14], values[15]);

            ValidateResult(result, values);
        }

        public void RunReflectionScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            Type[] operandTypes = new Type[ElementCount];
            Int16[] values = new Int16[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                operandTypes[i] = typeof(Int16);
                values[i] = TestLibrary.Generator.GetInt16();
            }

            object result = typeof(Vector256)
                                .GetMethod(nameof(Vector256.Create), operandTypes)
                                .Invoke(null, new object[] { values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11], values[12], values[13], values[14], values[15] });

            ValidateResult((Vector256<Int16>)(result), values);
        }

        private void ValidateResult(Vector256<Int16> result, Int16[] expectedValues, [CallerMemberName] string method = "")
        {
            Int16[] resultElements = new Int16[ElementCount];
            Unsafe.WriteUnaligned(ref Unsafe.As<Int16, byte>(ref resultElements[0]), result);
            ValidateResult(resultElements, expectedValues, method);
        }

        private void ValidateResult(Int16[] resultElements, Int16[] expectedValues, [CallerMemberName] string method = "")
        {
            for (var i = 0; i < ElementCount; i++)
            {
                if (resultElements[i] != expectedValues[i])
                {
                    Succeeded = false;
                    break;
                }
            }

            if (!Succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"Vector256.Create(Int16): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   value: ({string.Join(", ", expectedValues)})");
                TestLibrary.TestFramework.LogInformation($"  result: ({string.Join(", ", resultElements)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }
    }
}
