// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GenericValue.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MASES.EntityFrameworkCore.KNet.Serialization.Protobuf.Storage {

  /// <summary>Holder for reflection information generated from GenericValue.proto</summary>
  public static partial class GenericValueReflection {

    #region Descriptor
    /// <summary>File descriptor for GenericValue.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GenericValueReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJHZW5lcmljVmFsdWUucHJvdG8SB3N0b3JhZ2UaHGdvb2dsZS9wcm90b2J1",
            "Zi9zdHJ1Y3QucHJvdG8aH2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJv",
            "dG8ihQMKDEdlbmVyaWNWYWx1ZRIwCgpudWxsX3ZhbHVlGAEgASgOMhouZ29v",
            "Z2xlLnByb3RvYnVmLk51bGxWYWx1ZUgAEhQKCmJvb2xfdmFsdWUYAiABKAhI",
            "ABIUCgpieXRlX3ZhbHVlGAMgASgFSAASFQoLc2hvcnRfdmFsdWUYBCABKAVI",
            "ABITCglpbnRfdmFsdWUYBSABKAVIABIUCgpsb25nX3ZhbHVlGAYgASgDSAAS",
            "FQoLZmxvYXRfdmFsdWUYByABKAJIABIWCgxkb3VibGVfdmFsdWUYCCABKAFI",
            "ABIWCgxzdHJpbmdfdmFsdWUYCSABKAlIABIUCgpndWlkX3ZhbHVlGAogASgM",
            "SAASNAoOZGF0ZXRpbWVfdmFsdWUYCyABKAsyGi5nb29nbGUucHJvdG9idWYu",
            "VGltZXN0YW1wSAASOgoUZGF0ZXRpbWVvZmZzZXRfdmFsdWUYDCABKAsyGi5n",
            "b29nbGUucHJvdG9idWYuVGltZXN0YW1wSABCBgoEa2luZEKHAQo1bWFzZXMu",
            "ZW50aXR5ZnJhbWV3b3JrY29yZS5rbmV0LnNlcmlhbGl6YXRpb24ucHJvdG9i",
            "dWZCDEdlbmVyaWNWYWx1ZVABqgI9TUFTRVMuRW50aXR5RnJhbWV3b3JrQ29y",
            "ZS5LTmV0LlNlcmlhbGl6YXRpb24uUHJvdG9idWYuU3RvcmFnZWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.StructReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MASES.EntityFrameworkCore.KNet.Serialization.Protobuf.Storage.GenericValue), global::MASES.EntityFrameworkCore.KNet.Serialization.Protobuf.Storage.GenericValue.Parser, new[]{ "NullValue", "BoolValue", "ByteValue", "ShortValue", "IntValue", "LongValue", "FloatValue", "DoubleValue", "StringValue", "GuidValue", "DatetimeValue", "DatetimeoffsetValue" }, new[]{ "Kind" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// [START messages]
  /// Our address book file is just one of these.
  /// </summary>
  public sealed partial class GenericValue : pb::IMessage<GenericValue>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GenericValue> _parser = new pb::MessageParser<GenericValue>(() => new GenericValue());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GenericValue> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MASES.EntityFrameworkCore.KNet.Serialization.Protobuf.Storage.GenericValueReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GenericValue() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GenericValue(GenericValue other) : this() {
      switch (other.KindCase) {
        case KindOneofCase.NullValue:
          NullValue = other.NullValue;
          break;
        case KindOneofCase.BoolValue:
          BoolValue = other.BoolValue;
          break;
        case KindOneofCase.ByteValue:
          ByteValue = other.ByteValue;
          break;
        case KindOneofCase.ShortValue:
          ShortValue = other.ShortValue;
          break;
        case KindOneofCase.IntValue:
          IntValue = other.IntValue;
          break;
        case KindOneofCase.LongValue:
          LongValue = other.LongValue;
          break;
        case KindOneofCase.FloatValue:
          FloatValue = other.FloatValue;
          break;
        case KindOneofCase.DoubleValue:
          DoubleValue = other.DoubleValue;
          break;
        case KindOneofCase.StringValue:
          StringValue = other.StringValue;
          break;
        case KindOneofCase.GuidValue:
          GuidValue = other.GuidValue;
          break;
        case KindOneofCase.DatetimeValue:
          DatetimeValue = other.DatetimeValue.Clone();
          break;
        case KindOneofCase.DatetimeoffsetValue:
          DatetimeoffsetValue = other.DatetimeoffsetValue.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GenericValue Clone() {
      return new GenericValue(this);
    }

    /// <summary>Field number for the "null_value" field.</summary>
    public const int NullValueFieldNumber = 1;
    /// <summary>
    /// Represents a null value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.NullValue NullValue {
      get { return HasNullValue ? (global::Google.Protobuf.WellKnownTypes.NullValue) kind_ : global::Google.Protobuf.WellKnownTypes.NullValue.NullValue; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.NullValue;
      }
    }
    /// <summary>Gets whether the "null_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasNullValue {
      get { return kindCase_ == KindOneofCase.NullValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "null_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearNullValue() {
      if (HasNullValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "bool_value" field.</summary>
    public const int BoolValueFieldNumber = 2;
    /// <summary>
    /// Represents a boolean value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool BoolValue {
      get { return HasBoolValue ? (bool) kind_ : false; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.BoolValue;
      }
    }
    /// <summary>Gets whether the "bool_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasBoolValue {
      get { return kindCase_ == KindOneofCase.BoolValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "bool_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearBoolValue() {
      if (HasBoolValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "byte_value" field.</summary>
    public const int ByteValueFieldNumber = 3;
    /// <summary>
    /// Represents a int value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ByteValue {
      get { return HasByteValue ? (int) kind_ : 0; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.ByteValue;
      }
    }
    /// <summary>Gets whether the "byte_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasByteValue {
      get { return kindCase_ == KindOneofCase.ByteValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "byte_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearByteValue() {
      if (HasByteValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "short_value" field.</summary>
    public const int ShortValueFieldNumber = 4;
    /// <summary>
    /// Represents a int value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ShortValue {
      get { return HasShortValue ? (int) kind_ : 0; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.ShortValue;
      }
    }
    /// <summary>Gets whether the "short_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasShortValue {
      get { return kindCase_ == KindOneofCase.ShortValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "short_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearShortValue() {
      if (HasShortValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "int_value" field.</summary>
    public const int IntValueFieldNumber = 5;
    /// <summary>
    /// Represents a int value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int IntValue {
      get { return HasIntValue ? (int) kind_ : 0; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.IntValue;
      }
    }
    /// <summary>Gets whether the "int_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasIntValue {
      get { return kindCase_ == KindOneofCase.IntValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "int_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearIntValue() {
      if (HasIntValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "long_value" field.</summary>
    public const int LongValueFieldNumber = 6;
    /// <summary>
    /// Represents a long value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long LongValue {
      get { return HasLongValue ? (long) kind_ : 0L; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.LongValue;
      }
    }
    /// <summary>Gets whether the "long_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasLongValue {
      get { return kindCase_ == KindOneofCase.LongValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "long_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearLongValue() {
      if (HasLongValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "float_value" field.</summary>
    public const int FloatValueFieldNumber = 7;
    /// <summary>
    /// Represents a float value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float FloatValue {
      get { return HasFloatValue ? (float) kind_ : 0F; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.FloatValue;
      }
    }
    /// <summary>Gets whether the "float_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasFloatValue {
      get { return kindCase_ == KindOneofCase.FloatValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "float_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearFloatValue() {
      if (HasFloatValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "double_value" field.</summary>
    public const int DoubleValueFieldNumber = 8;
    /// <summary>
    /// Represents a double value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double DoubleValue {
      get { return HasDoubleValue ? (double) kind_ : 0D; }
      set {
        kind_ = value;
        kindCase_ = KindOneofCase.DoubleValue;
      }
    }
    /// <summary>Gets whether the "double_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasDoubleValue {
      get { return kindCase_ == KindOneofCase.DoubleValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "double_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearDoubleValue() {
      if (HasDoubleValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "string_value" field.</summary>
    public const int StringValueFieldNumber = 9;
    /// <summary>
    /// Represents a string value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string StringValue {
      get { return HasStringValue ? (string) kind_ : ""; }
      set {
        kind_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        kindCase_ = KindOneofCase.StringValue;
      }
    }
    /// <summary>Gets whether the "string_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasStringValue {
      get { return kindCase_ == KindOneofCase.StringValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "string_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearStringValue() {
      if (HasStringValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "guid_value" field.</summary>
    public const int GuidValueFieldNumber = 10;
    /// <summary>
    /// Represents a Guid value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pb::ByteString GuidValue {
      get { return HasGuidValue ? (pb::ByteString) kind_ : pb::ByteString.Empty; }
      set {
        kind_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        kindCase_ = KindOneofCase.GuidValue;
      }
    }
    /// <summary>Gets whether the "guid_value" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasGuidValue {
      get { return kindCase_ == KindOneofCase.GuidValue; }
    }
    /// <summary> Clears the value of the oneof if it's currently set to "guid_value" </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearGuidValue() {
      if (HasGuidValue) {
        ClearKind();
      }
    }

    /// <summary>Field number for the "datetime_value" field.</summary>
    public const int DatetimeValueFieldNumber = 11;
    /// <summary>
    /// Represents a Timestamp value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp DatetimeValue {
      get { return kindCase_ == KindOneofCase.DatetimeValue ? (global::Google.Protobuf.WellKnownTypes.Timestamp) kind_ : null; }
      set {
        kind_ = value;
        kindCase_ = value == null ? KindOneofCase.None : KindOneofCase.DatetimeValue;
      }
    }

    /// <summary>Field number for the "datetimeoffset_value" field.</summary>
    public const int DatetimeoffsetValueFieldNumber = 12;
    /// <summary>
    /// Represents a Timestamp value.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp DatetimeoffsetValue {
      get { return kindCase_ == KindOneofCase.DatetimeoffsetValue ? (global::Google.Protobuf.WellKnownTypes.Timestamp) kind_ : null; }
      set {
        kind_ = value;
        kindCase_ = value == null ? KindOneofCase.None : KindOneofCase.DatetimeoffsetValue;
      }
    }

    private object kind_;
    /// <summary>Enum of possible cases for the "kind" oneof.</summary>
    public enum KindOneofCase {
      None = 0,
      NullValue = 1,
      BoolValue = 2,
      ByteValue = 3,
      ShortValue = 4,
      IntValue = 5,
      LongValue = 6,
      FloatValue = 7,
      DoubleValue = 8,
      StringValue = 9,
      GuidValue = 10,
      DatetimeValue = 11,
      DatetimeoffsetValue = 12,
    }
    private KindOneofCase kindCase_ = KindOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public KindOneofCase KindCase {
      get { return kindCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearKind() {
      kindCase_ = KindOneofCase.None;
      kind_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GenericValue);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GenericValue other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NullValue != other.NullValue) return false;
      if (BoolValue != other.BoolValue) return false;
      if (ByteValue != other.ByteValue) return false;
      if (ShortValue != other.ShortValue) return false;
      if (IntValue != other.IntValue) return false;
      if (LongValue != other.LongValue) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(FloatValue, other.FloatValue)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DoubleValue, other.DoubleValue)) return false;
      if (StringValue != other.StringValue) return false;
      if (GuidValue != other.GuidValue) return false;
      if (!object.Equals(DatetimeValue, other.DatetimeValue)) return false;
      if (!object.Equals(DatetimeoffsetValue, other.DatetimeoffsetValue)) return false;
      if (KindCase != other.KindCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasNullValue) hash ^= NullValue.GetHashCode();
      if (HasBoolValue) hash ^= BoolValue.GetHashCode();
      if (HasByteValue) hash ^= ByteValue.GetHashCode();
      if (HasShortValue) hash ^= ShortValue.GetHashCode();
      if (HasIntValue) hash ^= IntValue.GetHashCode();
      if (HasLongValue) hash ^= LongValue.GetHashCode();
      if (HasFloatValue) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(FloatValue);
      if (HasDoubleValue) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DoubleValue);
      if (HasStringValue) hash ^= StringValue.GetHashCode();
      if (HasGuidValue) hash ^= GuidValue.GetHashCode();
      if (kindCase_ == KindOneofCase.DatetimeValue) hash ^= DatetimeValue.GetHashCode();
      if (kindCase_ == KindOneofCase.DatetimeoffsetValue) hash ^= DatetimeoffsetValue.GetHashCode();
      hash ^= (int) kindCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasNullValue) {
        output.WriteRawTag(8);
        output.WriteEnum((int) NullValue);
      }
      if (HasBoolValue) {
        output.WriteRawTag(16);
        output.WriteBool(BoolValue);
      }
      if (HasByteValue) {
        output.WriteRawTag(24);
        output.WriteInt32(ByteValue);
      }
      if (HasShortValue) {
        output.WriteRawTag(32);
        output.WriteInt32(ShortValue);
      }
      if (HasIntValue) {
        output.WriteRawTag(40);
        output.WriteInt32(IntValue);
      }
      if (HasLongValue) {
        output.WriteRawTag(48);
        output.WriteInt64(LongValue);
      }
      if (HasFloatValue) {
        output.WriteRawTag(61);
        output.WriteFloat(FloatValue);
      }
      if (HasDoubleValue) {
        output.WriteRawTag(65);
        output.WriteDouble(DoubleValue);
      }
      if (HasStringValue) {
        output.WriteRawTag(74);
        output.WriteString(StringValue);
      }
      if (HasGuidValue) {
        output.WriteRawTag(82);
        output.WriteBytes(GuidValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeValue) {
        output.WriteRawTag(90);
        output.WriteMessage(DatetimeValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeoffsetValue) {
        output.WriteRawTag(98);
        output.WriteMessage(DatetimeoffsetValue);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasNullValue) {
        output.WriteRawTag(8);
        output.WriteEnum((int) NullValue);
      }
      if (HasBoolValue) {
        output.WriteRawTag(16);
        output.WriteBool(BoolValue);
      }
      if (HasByteValue) {
        output.WriteRawTag(24);
        output.WriteInt32(ByteValue);
      }
      if (HasShortValue) {
        output.WriteRawTag(32);
        output.WriteInt32(ShortValue);
      }
      if (HasIntValue) {
        output.WriteRawTag(40);
        output.WriteInt32(IntValue);
      }
      if (HasLongValue) {
        output.WriteRawTag(48);
        output.WriteInt64(LongValue);
      }
      if (HasFloatValue) {
        output.WriteRawTag(61);
        output.WriteFloat(FloatValue);
      }
      if (HasDoubleValue) {
        output.WriteRawTag(65);
        output.WriteDouble(DoubleValue);
      }
      if (HasStringValue) {
        output.WriteRawTag(74);
        output.WriteString(StringValue);
      }
      if (HasGuidValue) {
        output.WriteRawTag(82);
        output.WriteBytes(GuidValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeValue) {
        output.WriteRawTag(90);
        output.WriteMessage(DatetimeValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeoffsetValue) {
        output.WriteRawTag(98);
        output.WriteMessage(DatetimeoffsetValue);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasNullValue) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) NullValue);
      }
      if (HasBoolValue) {
        size += 1 + 1;
      }
      if (HasByteValue) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ByteValue);
      }
      if (HasShortValue) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ShortValue);
      }
      if (HasIntValue) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(IntValue);
      }
      if (HasLongValue) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(LongValue);
      }
      if (HasFloatValue) {
        size += 1 + 4;
      }
      if (HasDoubleValue) {
        size += 1 + 8;
      }
      if (HasStringValue) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StringValue);
      }
      if (HasGuidValue) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(GuidValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeValue) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DatetimeValue);
      }
      if (kindCase_ == KindOneofCase.DatetimeoffsetValue) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DatetimeoffsetValue);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GenericValue other) {
      if (other == null) {
        return;
      }
      switch (other.KindCase) {
        case KindOneofCase.NullValue:
          NullValue = other.NullValue;
          break;
        case KindOneofCase.BoolValue:
          BoolValue = other.BoolValue;
          break;
        case KindOneofCase.ByteValue:
          ByteValue = other.ByteValue;
          break;
        case KindOneofCase.ShortValue:
          ShortValue = other.ShortValue;
          break;
        case KindOneofCase.IntValue:
          IntValue = other.IntValue;
          break;
        case KindOneofCase.LongValue:
          LongValue = other.LongValue;
          break;
        case KindOneofCase.FloatValue:
          FloatValue = other.FloatValue;
          break;
        case KindOneofCase.DoubleValue:
          DoubleValue = other.DoubleValue;
          break;
        case KindOneofCase.StringValue:
          StringValue = other.StringValue;
          break;
        case KindOneofCase.GuidValue:
          GuidValue = other.GuidValue;
          break;
        case KindOneofCase.DatetimeValue:
          if (DatetimeValue == null) {
            DatetimeValue = new global::Google.Protobuf.WellKnownTypes.Timestamp();
          }
          DatetimeValue.MergeFrom(other.DatetimeValue);
          break;
        case KindOneofCase.DatetimeoffsetValue:
          if (DatetimeoffsetValue == null) {
            DatetimeoffsetValue = new global::Google.Protobuf.WellKnownTypes.Timestamp();
          }
          DatetimeoffsetValue.MergeFrom(other.DatetimeoffsetValue);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            kind_ = input.ReadEnum();
            kindCase_ = KindOneofCase.NullValue;
            break;
          }
          case 16: {
            BoolValue = input.ReadBool();
            break;
          }
          case 24: {
            ByteValue = input.ReadInt32();
            break;
          }
          case 32: {
            ShortValue = input.ReadInt32();
            break;
          }
          case 40: {
            IntValue = input.ReadInt32();
            break;
          }
          case 48: {
            LongValue = input.ReadInt64();
            break;
          }
          case 61: {
            FloatValue = input.ReadFloat();
            break;
          }
          case 65: {
            DoubleValue = input.ReadDouble();
            break;
          }
          case 74: {
            StringValue = input.ReadString();
            break;
          }
          case 82: {
            GuidValue = input.ReadBytes();
            break;
          }
          case 90: {
            global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            if (kindCase_ == KindOneofCase.DatetimeValue) {
              subBuilder.MergeFrom(DatetimeValue);
            }
            input.ReadMessage(subBuilder);
            DatetimeValue = subBuilder;
            break;
          }
          case 98: {
            global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            if (kindCase_ == KindOneofCase.DatetimeoffsetValue) {
              subBuilder.MergeFrom(DatetimeoffsetValue);
            }
            input.ReadMessage(subBuilder);
            DatetimeoffsetValue = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            kind_ = input.ReadEnum();
            kindCase_ = KindOneofCase.NullValue;
            break;
          }
          case 16: {
            BoolValue = input.ReadBool();
            break;
          }
          case 24: {
            ByteValue = input.ReadInt32();
            break;
          }
          case 32: {
            ShortValue = input.ReadInt32();
            break;
          }
          case 40: {
            IntValue = input.ReadInt32();
            break;
          }
          case 48: {
            LongValue = input.ReadInt64();
            break;
          }
          case 61: {
            FloatValue = input.ReadFloat();
            break;
          }
          case 65: {
            DoubleValue = input.ReadDouble();
            break;
          }
          case 74: {
            StringValue = input.ReadString();
            break;
          }
          case 82: {
            GuidValue = input.ReadBytes();
            break;
          }
          case 90: {
            global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            if (kindCase_ == KindOneofCase.DatetimeValue) {
              subBuilder.MergeFrom(DatetimeValue);
            }
            input.ReadMessage(subBuilder);
            DatetimeValue = subBuilder;
            break;
          }
          case 98: {
            global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            if (kindCase_ == KindOneofCase.DatetimeoffsetValue) {
              subBuilder.MergeFrom(DatetimeoffsetValue);
            }
            input.ReadMessage(subBuilder);
            DatetimeoffsetValue = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code