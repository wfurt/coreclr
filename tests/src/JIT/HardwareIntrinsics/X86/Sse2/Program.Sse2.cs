// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        static Program()
        {
            TestList = new Dictionary<string, Action>() {
                ["Add.Double"] = AddDouble,
                ["Add.Byte"] = AddByte,
                ["Add.Int16"] = AddInt16,
                ["Add.Int32"] = AddInt32,
                ["Add.Int64"] = AddInt64,
                ["Add.SByte"] = AddSByte,
                ["Add.UInt16"] = AddUInt16,
                ["Add.UInt32"] = AddUInt32,
                ["Add.UInt64"] = AddUInt64,
                ["AddSaturate.Byte"] = AddSaturateByte,
                ["AddSaturate.SByte"] = AddSaturateSByte,
                ["AddSaturate.Int16"] = AddSaturateInt16,
                ["AddSaturate.UInt16"] = AddSaturateUInt16,
                ["AddScalar.Double"] = AddScalarDouble,
                ["And.Double"] = AndDouble,
                ["And.Byte"] = AndByte,
                ["And.Int16"] = AndInt16,
                ["And.Int32"] = AndInt32,
                ["And.Int64"] = AndInt64,
                ["And.SByte"] = AndSByte,
                ["And.UInt16"] = AndUInt16,
                ["And.UInt32"] = AndUInt32,
                ["And.UInt64"] = AndUInt64,
                ["AndNot.Double"] = AndNotDouble,
                ["AndNot.Byte"] = AndNotByte,
                ["AndNot.Int16"] = AndNotInt16,
                ["AndNot.Int32"] = AndNotInt32,
                ["AndNot.Int64"] = AndNotInt64,
                ["AndNot.SByte"] = AndNotSByte,
                ["AndNot.UInt16"] = AndNotUInt16,
                ["AndNot.UInt32"] = AndNotUInt32,
                ["AndNot.UInt64"] = AndNotUInt64,
                ["Average.Byte"] = AverageByte,
                ["Average.UInt16"] = AverageUInt16,
                ["CompareEqual.Double"] = CompareEqualDouble,
                ["CompareEqual.Byte"] = CompareEqualByte,
                ["CompareEqual.Int16"] = CompareEqualInt16,
                ["CompareEqual.Int32"] = CompareEqualInt32,
                ["CompareEqual.SByte"] = CompareEqualSByte,
                ["CompareEqual.UInt16"] = CompareEqualUInt16,
                ["CompareEqual.UInt32"] = CompareEqualUInt32,
                ["CompareEqualScalar.Double"] = CompareEqualScalarDouble,
                ["CompareEqualOrderedScalar.Boolean"] = CompareEqualOrderedScalarBoolean,
                ["CompareEqualUnorderedScalar.Boolean"] = CompareEqualUnorderedScalarBoolean,
                ["CompareGreaterThan.Double"] = CompareGreaterThanDouble,
                ["CompareGreaterThan.Int16"] = CompareGreaterThanInt16,
                ["CompareGreaterThan.Int32"] = CompareGreaterThanInt32,
                ["CompareGreaterThan.SByte"] = CompareGreaterThanSByte,
                ["CompareGreaterThanScalar.Double"] = CompareGreaterThanScalarDouble,
                ["CompareGreaterThanOrderedScalar.Boolean"] = CompareGreaterThanOrderedScalarBoolean,
                ["CompareGreaterThanUnorderedScalar.Boolean"] = CompareGreaterThanUnorderedScalarBoolean,
                ["CompareGreaterThanOrEqual.Double"] = CompareGreaterThanOrEqualDouble,
                ["CompareGreaterThanOrEqualScalar.Double"] = CompareGreaterThanOrEqualScalarDouble,
                ["CompareGreaterThanOrEqualOrderedScalar.Boolean"] = CompareGreaterThanOrEqualOrderedScalarBoolean,
                ["CompareGreaterThanOrEqualUnorderedScalar.Boolean"] = CompareGreaterThanOrEqualUnorderedScalarBoolean,
                ["CompareLessThan.Double"] = CompareLessThanDouble,
                ["CompareLessThan.Int16"] = CompareLessThanInt16,
                ["CompareLessThan.Int32"] = CompareLessThanInt32,
                ["CompareLessThan.SByte"] = CompareLessThanSByte,
                ["CompareLessThanScalar.Double"] = CompareLessThanScalarDouble,
                ["CompareLessThanOrderedScalar.Boolean"] = CompareLessThanOrderedScalarBoolean,
                ["CompareLessThanUnorderedScalar.Boolean"] = CompareLessThanUnorderedScalarBoolean,
                ["CompareLessThanOrEqual.Double"] = CompareLessThanOrEqualDouble,
                ["CompareLessThanOrEqualScalar.Double"] = CompareLessThanOrEqualScalarDouble,
                ["CompareLessThanOrEqualOrderedScalar.Boolean"] = CompareLessThanOrEqualOrderedScalarBoolean,
                ["CompareLessThanOrEqualUnorderedScalar.Boolean"] = CompareLessThanOrEqualUnorderedScalarBoolean,
                ["CompareNotEqual.Double"] = CompareNotEqualDouble,
                ["CompareNotEqualScalar.Double"] = CompareNotEqualScalarDouble,
                ["CompareNotEqualOrderedScalar.Boolean"] = CompareNotEqualOrderedScalarBoolean,
                ["CompareNotEqualUnorderedScalar.Boolean"] = CompareNotEqualUnorderedScalarBoolean,
                ["CompareNotGreaterThan.Double"] = CompareNotGreaterThanDouble,
                ["CompareNotGreaterThanScalar.Double"] = CompareNotGreaterThanScalarDouble,
                ["CompareNotGreaterThanOrEqual.Double"] = CompareNotGreaterThanOrEqualDouble,
                ["CompareNotGreaterThanOrEqualScalar.Double"] = CompareNotGreaterThanOrEqualScalarDouble,
                ["CompareNotLessThan.Double"] = CompareNotLessThanDouble,
                ["CompareNotLessThanScalar.Double"] = CompareNotLessThanScalarDouble,
                ["CompareNotLessThanOrEqual.Double"] = CompareNotLessThanOrEqualDouble,
                ["CompareNotLessThanOrEqualScalar.Double"] = CompareNotLessThanOrEqualScalarDouble,
                ["CompareOrdered.Double"] = CompareOrderedDouble,
                ["CompareOrderedScalar.Double"] = CompareOrderedScalarDouble,
                ["CompareUnordered.Double"] = CompareUnorderedDouble,
                ["CompareUnorderedScalar.Double"] = CompareUnorderedScalarDouble,
                ["ConvertToInt32.Vector128Double"] = ConvertToInt32Vector128Double,
                ["ConvertToInt32.Vector128Int32"] = ConvertToInt32Vector128Int32,
                ["ConvertToInt32WithTruncation.Vector128Double"] = ConvertToInt32WithTruncationVector128Double,
                ["ConvertToInt64.Vector128Double"] = ConvertToInt64Vector128Double,
                ["ConvertToInt64.Vector128Int64"] = ConvertToInt64Vector128Int64,
                ["ConvertToInt64WithTruncation.Vector128Double"] = ConvertToInt64WithTruncationVector128Double,
                ["ConvertToUInt32.Vector128UInt32"] = ConvertToUInt32Vector128UInt32,
                ["ConvertToUInt64.Vector128UInt64"] = ConvertToUInt64Vector128UInt64,
                ["ConvertToVector128Double.Vector128Single"] = ConvertToVector128DoubleVector128Single,
                ["ConvertToVector128Double.Vector128Int32"] = ConvertToVector128DoubleVector128Int32,
                ["ConvertToVector128Int32.Vector128Double"] = ConvertToVector128Int32Vector128Double,
                ["ConvertToVector128Int32.Vector128Single"] = ConvertToVector128Int32Vector128Single,
                ["ConvertToVector128Int32WithTruncation.Vector128Double"] = ConvertToVector128Int32WithTruncationVector128Double,
                ["ConvertToVector128Int32WithTruncation.Vector128Single"] = ConvertToVector128Int32WithTruncationVector128Single,
                ["ConvertToVector128Single.Vector128Double"] = ConvertToVector128SingleVector128Double,
                ["ConvertToVector128Single.Vector128Int32"] = ConvertToVector128SingleVector128Int32,
                ["Divide.Double"] = DivideDouble,
                ["DivideScalar.Double"] = DivideScalarDouble,
                ["Extract.UInt16.1"] = ExtractUInt161,
                ["Extract.UInt16.129"] = ExtractUInt16129,
                ["Insert.Int16.1"] = InsertInt161,
                ["Insert.UInt16.1"] = InsertUInt161,
                ["Insert.Int16.129"] = InsertInt16129,
                ["Insert.UInt16.129"] = InsertUInt16129,
                ["LoadVector128.Double"] = LoadVector128Double,
                ["LoadVector128.Byte"] = LoadVector128Byte,
                ["LoadVector128.SByte"] = LoadVector128SByte,
                ["LoadVector128.Int16"] = LoadVector128Int16,
                ["LoadVector128.UInt16"] = LoadVector128UInt16,
                ["LoadVector128.Int32"] = LoadVector128Int32,
                ["LoadVector128.UInt32"] = LoadVector128UInt32,
                ["LoadVector128.Int64"] = LoadVector128Int64,
                ["LoadVector128.UInt64"] = LoadVector128UInt64,
                ["LoadScalarVector128.Double"] = LoadScalarVector128Double,
                ["LoadScalarVector128.Int32"] = LoadScalarVector128Int32,
                ["LoadScalarVector128.UInt32"] = LoadScalarVector128UInt32,
                ["LoadScalarVector128.Int64"] = LoadScalarVector128Int64,
                ["LoadScalarVector128.UInt64"] = LoadScalarVector128UInt64,
                ["Max.Double"] = MaxDouble,
                ["Max.Byte"] = MaxByte,
                ["Max.Int16"] = MaxInt16,
                ["MaxScalar.Double"] = MaxScalarDouble,
                ["Min.Double"] = MinDouble,
                ["Min.Byte"] = MinByte,
                ["Min.Int16"] = MinInt16,
                ["MinScalar.Double"] = MinScalarDouble,
                ["Multiply.Double"] = MultiplyDouble,
                ["MultiplyScalar.Double"] = MultiplyScalarDouble,
                ["MultiplyAddAdjacent.Int32"] = MultiplyAddAdjacentInt32,
                ["MultiplyLow.Int16"] = MultiplyLowInt16,
                ["MultiplyLow.UInt16"] = MultiplyLowUInt16,
                ["Or.Double"] = OrDouble,
                ["Or.Byte"] = OrByte,
                ["Or.Int16"] = OrInt16,
                ["Or.Int32"] = OrInt32,
                ["Or.Int64"] = OrInt64,
                ["Or.SByte"] = OrSByte,
                ["Or.UInt16"] = OrUInt16,
                ["Or.UInt32"] = OrUInt32,
                ["Or.UInt64"] = OrUInt64,
                ["PackSignedSaturate.Int16"] = PackSignedSaturateInt16,
                ["PackSignedSaturate.SByte"] = PackSignedSaturateSByte,
                ["PackUnsignedSaturate.Byte"] = PackUnsignedSaturateByte,
                ["ShiftLeftLogical.Int16.1"] = ShiftLeftLogicalInt161,
                ["ShiftLeftLogical.UInt16.1"] = ShiftLeftLogicalUInt161,
                ["ShiftLeftLogical.Int32.1"] = ShiftLeftLogicalInt321,
                ["ShiftLeftLogical.UInt32.1"] = ShiftLeftLogicalUInt321,
                ["ShiftLeftLogical.Int64.1"] = ShiftLeftLogicalInt641,
                ["ShiftLeftLogical.UInt64.1"] = ShiftLeftLogicalUInt641,
                ["ShiftLeftLogical.Int16.16"] = ShiftLeftLogicalInt1616,
                ["ShiftLeftLogical.UInt16.16"] = ShiftLeftLogicalUInt1616,
                ["ShiftLeftLogical.Int32.32"] = ShiftLeftLogicalInt3232,
                ["ShiftLeftLogical.UInt32.32"] = ShiftLeftLogicalUInt3232,
                ["ShiftLeftLogical.Int64.64"] = ShiftLeftLogicalInt6464,
                ["ShiftLeftLogical.UInt64.64"] = ShiftLeftLogicalUInt6464,
                ["ShiftLeftLogical128BitLane.SByte.1"] = ShiftLeftLogical128BitLaneSByte1,
                ["ShiftLeftLogical128BitLane.Byte.1"] = ShiftLeftLogical128BitLaneByte1,
                ["ShiftLeftLogical128BitLane.Int16.1"] = ShiftLeftLogical128BitLaneInt161,
                ["ShiftLeftLogical128BitLane.UInt16.1"] = ShiftLeftLogical128BitLaneUInt161,
                ["ShiftLeftLogical128BitLane.Int32.1"] = ShiftLeftLogical128BitLaneInt321,
                ["ShiftLeftLogical128BitLane.UInt32.1"] = ShiftLeftLogical128BitLaneUInt321,
                ["ShiftLeftLogical128BitLane.Int64.1"] = ShiftLeftLogical128BitLaneInt641,
                ["ShiftLeftLogical128BitLane.UInt64.1"] = ShiftLeftLogical128BitLaneUInt641,
                ["ShiftRightArithmetic.Int16.1"] = ShiftRightArithmeticInt161,
                ["ShiftRightArithmetic.Int32.1"] = ShiftRightArithmeticInt321,
                ["ShiftRightArithmetic.Int16.16"] = ShiftRightArithmeticInt1616,
                ["ShiftRightArithmetic.Int32.32"] = ShiftRightArithmeticInt3232,
                ["ShiftRightLogical.Int16.1"] = ShiftRightLogicalInt161,
                ["ShiftRightLogical.UInt16.1"] = ShiftRightLogicalUInt161,
                ["ShiftRightLogical.Int32.1"] = ShiftRightLogicalInt321,
                ["ShiftRightLogical.UInt32.1"] = ShiftRightLogicalUInt321,
                ["ShiftRightLogical.Int64.1"] = ShiftRightLogicalInt641,
                ["ShiftRightLogical.UInt64.1"] = ShiftRightLogicalUInt641,
                ["ShiftRightLogical.Int16.16"] = ShiftRightLogicalInt1616,
                ["ShiftRightLogical.UInt16.16"] = ShiftRightLogicalUInt1616,
                ["ShiftRightLogical.Int32.32"] = ShiftRightLogicalInt3232,
                ["ShiftRightLogical.UInt32.32"] = ShiftRightLogicalUInt3232,
                ["ShiftRightLogical.Int64.64"] = ShiftRightLogicalInt6464,
                ["ShiftRightLogical.UInt64.64"] = ShiftRightLogicalUInt6464,
                ["ShiftRightLogical128BitLane.SByte.1"] = ShiftRightLogical128BitLaneSByte1,
                ["ShiftRightLogical128BitLane.Byte.1"] = ShiftRightLogical128BitLaneByte1,
                ["ShiftRightLogical128BitLane.Int16.1"] = ShiftRightLogical128BitLaneInt161,
                ["ShiftRightLogical128BitLane.UInt16.1"] = ShiftRightLogical128BitLaneUInt161,
                ["ShiftRightLogical128BitLane.Int32.1"] = ShiftRightLogical128BitLaneInt321,
                ["ShiftRightLogical128BitLane.UInt32.1"] = ShiftRightLogical128BitLaneUInt321,
                ["ShiftRightLogical128BitLane.Int64.1"] = ShiftRightLogical128BitLaneInt641,
                ["ShiftRightLogical128BitLane.UInt64.1"] = ShiftRightLogical128BitLaneUInt641,
                ["Subtract.Double"] = SubtractDouble,
                ["Subtract.Byte"] = SubtractByte,
                ["Subtract.Int16"] = SubtractInt16,
                ["Subtract.Int32"] = SubtractInt32,
                ["Subtract.Int64"] = SubtractInt64,
                ["Subtract.SByte"] = SubtractSByte,
                ["Subtract.UInt16"] = SubtractUInt16,
                ["Subtract.UInt32"] = SubtractUInt32,
                ["Subtract.UInt64"] = SubtractUInt64,
                ["SubtractSaturate.Byte"] = SubtractSaturateByte,
                ["SubtractSaturate.SByte"] = SubtractSaturateSByte,
                ["SubtractSaturate.Int16"] = SubtractSaturateInt16,
                ["SubtractSaturate.UInt16"] = SubtractSaturateUInt16,
                ["SubtractScalar.Double"] = SubtractScalarDouble,
                ["SumAbsoluteDifferences.UInt16"] = SumAbsoluteDifferencesUInt16,
                ["UnpackHigh.Double"] = UnpackHighDouble,
                ["UnpackHigh.Int64"] = UnpackHighInt64,
                ["UnpackHigh.UInt64"] = UnpackHighUInt64,
                ["UnpackHigh.Int32"] = UnpackHighInt32,
                ["UnpackHigh.UInt32"] = UnpackHighUInt32,
                ["UnpackHigh.Int16"] = UnpackHighInt16,
                ["UnpackHigh.UInt16"] = UnpackHighUInt16,
                ["UnpackHigh.SByte"] = UnpackHighSByte,
                ["UnpackHigh.Byte"] = UnpackHighByte,
                ["UnpackLow.Double"] = UnpackLowDouble,
                ["UnpackLow.Int64"] = UnpackLowInt64,
                ["UnpackLow.UInt64"] = UnpackLowUInt64,
                ["UnpackLow.Int32"] = UnpackLowInt32,
                ["UnpackLow.UInt32"] = UnpackLowUInt32,
                ["UnpackLow.Int16"] = UnpackLowInt16,
                ["UnpackLow.UInt16"] = UnpackLowUInt16,
                ["UnpackLow.SByte"] = UnpackLowSByte,
                ["UnpackLow.Byte"] = UnpackLowByte,
                ["Xor.Double"] = XorDouble,
                ["Xor.Byte"] = XorByte,
                ["Xor.Int16"] = XorInt16,
                ["Xor.Int32"] = XorInt32,
                ["Xor.Int64"] = XorInt64,
                ["Xor.SByte"] = XorSByte,
                ["Xor.UInt16"] = XorUInt16,
                ["Xor.UInt32"] = XorUInt32,
                ["Xor.UInt64"] = XorUInt64,
            };
        }
    }
}
