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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace JIT.HardwareIntrinsics.General
{
    public static partial class Program
    {
        private static void GetAndWithElementInt327()
        {
            var test = new VectorGetAndWithElement__GetAndWithElementInt327();

            // Validates basic functionality works
            test.RunBasicScenario();

            // Validates calling via reflection works
            test.RunReflectionScenario();

            // Validates that invalid indices throws ArgumentOutOfRangeException
            test.RunArgumentOutOfRangeScenario();

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class VectorGetAndWithElement__GetAndWithElementInt327
    {
        private static readonly int LargestVectorSize = 32;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector256<Int32>>() / sizeof(Int32);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario(int imm = 7, bool expectedOutOfRangeException = false)
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            Int32[] values = new Int32[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetInt32();
            }

            Vector256<Int32> value = Vector256.Create(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

            bool succeeded = !expectedOutOfRangeException;

            try
            {
                Int32 result = value.GetElement(imm);
                ValidateGetResult(result, values);
            }
            catch (ArgumentOutOfRangeException)
            {
                succeeded = expectedOutOfRangeException;
            }

            if (!succeeded)
            {
                Succeeded = false;

                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.GetElement({imm}): {nameof(RunBasicScenario)} failed to throw ArgumentOutOfRangeException.");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }

            succeeded = !expectedOutOfRangeException;

            Int32 insertedValue = TestLibrary.Generator.GetInt32();

            try
            {
                Vector256<Int32> result2 = value.WithElement(imm, insertedValue);
                ValidateWithResult(result2, values, insertedValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                succeeded = expectedOutOfRangeException;
            }

            if (!succeeded)
            {
                Succeeded = false;

                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.WithElement({imm}): {nameof(RunBasicScenario)} failed to throw ArgumentOutOfRangeException.");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }

        public void RunReflectionScenario(int imm = 7, bool expectedOutOfRangeException = false)
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            Int32[] values = new Int32[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetInt32();
            }

            Vector256<Int32> value = Vector256.Create(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

            bool succeeded = !expectedOutOfRangeException;

            try
            {
                object result = typeof(Vector256<Int32>)
                                    .GetMethod(nameof(Vector256<Int32>.GetElement), new Type[] { typeof(int) })
                                    .Invoke(value, new object[] { imm });
                ValidateGetResult((Int32)(result), values);
            }
            catch (TargetInvocationException e)
            {
                succeeded = expectedOutOfRangeException
                          && e.InnerException is ArgumentOutOfRangeException;
            }

            if (!succeeded)
            {
                Succeeded = false;

                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.GetElement({imm}): {nameof(RunReflectionScenario)} failed to throw ArgumentOutOfRangeException.");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }

            succeeded = !expectedOutOfRangeException;

            Int32 insertedValue = TestLibrary.Generator.GetInt32();

            try
            {
                object result2 = typeof(Vector256<Int32>)
                                    .GetMethod(nameof(Vector256<Int32>.WithElement), new Type[] { typeof(int), typeof(Int32) })
                                    .Invoke(value, new object[] { imm, insertedValue });
                ValidateWithResult((Vector256<Int32>)(result2), values, insertedValue);
            }
            catch (TargetInvocationException e)
            {
                succeeded = expectedOutOfRangeException
                          && e.InnerException is ArgumentOutOfRangeException;
            }

            if (!succeeded)
            {
                Succeeded = false;

                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.WithElement({imm}): {nameof(RunReflectionScenario)} failed to throw ArgumentOutOfRangeException.");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }

        public void RunArgumentOutOfRangeScenario()
        {
            RunBasicScenario(7 - ElementCount, expectedOutOfRangeException: true);
            RunBasicScenario(7 + ElementCount, expectedOutOfRangeException: true);

            RunReflectionScenario(7 - ElementCount, expectedOutOfRangeException: true);
            RunReflectionScenario(7 + ElementCount, expectedOutOfRangeException: true);
        }

        private void ValidateGetResult(Int32 result, Int32[] values, [CallerMemberName] string method = "")
        {
            if (result != values[7])
            {
                Succeeded = false;

                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.GetElement(7): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   value: ({string.Join(", ", values)})");
                TestLibrary.TestFramework.LogInformation($"  result: ({result})");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }

        private void ValidateWithResult(Vector256<Int32> result, Int32[] values, Int32 insertedValue, [CallerMemberName] string method = "")
        {
            Int32[] resultElements = new Int32[ElementCount];
            Unsafe.WriteUnaligned(ref Unsafe.As<Int32, byte>(ref resultElements[0]), result);
            ValidateWithResult(resultElements, values, insertedValue, method);
        }

        private void ValidateWithResult(Int32[] result, Int32[] values, Int32 insertedValue, [CallerMemberName] string method = "")
        {
            for (int i = 0; i < ElementCount; i++)
            {
                if ((i != 7) && (result[i] != values[i]))
                {
                    Succeeded = false;
                    break;
                }
            }

            if (result[7] != insertedValue)
            {
                Succeeded = false;
            }

            if (!Succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"Vector256<Int32.WithElement(7): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   value: ({string.Join(", ", values)})");
                TestLibrary.TestFramework.LogInformation($"  insert: insertedValue");
                TestLibrary.TestFramework.LogInformation($"  result: ({string.Join(", ", result)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }
    }
}
