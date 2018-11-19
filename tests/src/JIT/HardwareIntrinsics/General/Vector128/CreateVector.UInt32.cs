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
        private static void CreateVectorUInt32()
        {
            var test = new VectorCreate__CreateVectorUInt32();

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

    public sealed unsafe class VectorCreate__CreateVectorUInt32
    {
        private static readonly int LargestVectorSize = 16;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector128<UInt32>>() / sizeof(UInt32);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            UInt32 lowerValue = TestLibrary.Generator.GetUInt32();
            Vector64<UInt32> lower = Vector64.Create(lowerValue);

            UInt32 upperValue = TestLibrary.Generator.GetUInt32();
            Vector64<UInt32> upper = Vector64.Create(upperValue);

            Vector128<UInt32> result = Vector128.Create(lower, upper);

            ValidateResult(result, lowerValue, upperValue);
        }

        public void RunReflectionScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            UInt32 lowerValue = TestLibrary.Generator.GetUInt32();
            Vector64<UInt32> lower = Vector64.Create(lowerValue);

            UInt32 upperValue = TestLibrary.Generator.GetUInt32();
            Vector64<UInt32> upper = Vector64.Create(upperValue);

            object result = typeof(Vector128)
                                .GetMethod(nameof(Vector128.Create), new Type[] { typeof(Vector64<UInt32>), typeof(Vector64<UInt32>) })
                                .Invoke(null, new object[] { lower, upper });

            ValidateResult((Vector128<UInt32>)(result), lowerValue, upperValue);
        }

        private void ValidateResult(Vector128<UInt32> result, UInt32 expectedLowerValue, UInt32 expectedUpperValue, [CallerMemberName] string method = "")
        {
            UInt32[] resultElements = new UInt32[ElementCount];
            Unsafe.WriteUnaligned(ref Unsafe.As<UInt32, byte>(ref resultElements[0]), result);
            ValidateResult(resultElements, expectedLowerValue, expectedUpperValue, method);
        }

        private void ValidateResult(UInt32[] resultElements, UInt32 expectedLowerValue, UInt32 expectedUpperValue, [CallerMemberName] string method = "")
        {
            for (var i = 0; i < ElementCount / 2; i++)
            {
                if (resultElements[i] != expectedLowerValue)
                {
                    Succeeded = false;
                    break;
                }
            }

            for (var i = ElementCount / 2; i < ElementCount; i++)
            {
                if (resultElements[i] != expectedUpperValue)
                {
                    Succeeded = false;
                    break;
                }
            }

            if (!Succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"Vector128.Create(UInt32): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   lower: {expectedLowerValue}");
                TestLibrary.TestFramework.LogInformation($"   upper: {expectedUpperValue}");
                TestLibrary.TestFramework.LogInformation($"  result: ({string.Join(", ", resultElements)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }
    }
}
