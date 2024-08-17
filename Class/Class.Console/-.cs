global using Any = Avalon.Infra.Any;
global using Data = Avalon.Infra.Data;
global using StringData = Avalon.Infra.StringData;
global using InfraRange = Avalon.Infra.Range;
global using StringCreate = Avalon.Infra.StringComp;
global using StringJoin = Avalon.Infra.StringJoin;
global using Compare = Avalon.Infra.Less;
global using CompareMid = Avalon.Infra.CompareMid;
global using StringCompare = Avalon.Infra.StringLess;
global using CharForm = Avalon.Infra.CharForm;
global using InfraValue = Avalon.Infra.Value;
global using InfraInfra = Avalon.Infra.Infra;
global using List = Avalon.List.List;
global using Iter = Avalon.List.Iter;
global using Array = Avalon.List.Array;
global using Table = Avalon.List.Table;
global using TableIter = Avalon.List.TableIter;
global using ListInfra = Avalon.List.Infra;
global using Text = Avalon.Text.Text;
global using TextCompare = Avalon.Text.Less;
global using Format = Avalon.Text.Write;
global using FormatArg = Avalon.Text.WriteArg;
global using IntParse = Avalon.Text.IntParse;
global using TextInfra = Avalon.Text.Infra;
global using StorageArrange = Avalon.Storage.Arrange;
global using StorageInfra = Avalon.Storage.Infra;
global using Out = Avalon.Console.Out;
global using ConsoleConsole = Avalon.Console.Console;
global using EntryEntry = Avalon.Entry.Entry;
global using Source = Class.Infra.Source;
global using ClassClass = Class.Infra.Class;
global using Field = Class.Infra.Field;
global using Maide = Class.Infra.Maide;
global using Var = Class.Infra.Var;
global using ClassModule = Class.Infra.Module;
global using Count = Class.Infra.Count;
global using CountList = Class.Infra.CountList;
global using Error = Class.Infra.Error;
global using ErrorKind = Class.Infra.ErrorKind;
global using Range = Class.Infra.Range;
global using ModuleRef = Class.Infra.ModuleRef;
global using ModuleRefCompare = Class.Infra.ModuleRefCompare;
global using ClassStorage = Class.Infra.Storage;
global using NameCheck = Class.Infra.NameCheck;
global using StoragePathCheck = Class.Infra.StoragePathCheck;
global using PrintableChar = Class.Infra.PrintableChar;
global using ClassInfra = Class.Infra.Infra;
global using BinaryBinary = Class.Binary.Binary;
global using BinaryClass = Class.Binary.Class;
global using BinaryImport = Class.Binary.Import;
global using BinaryPart = Class.Binary.Part;
global using BinaryField = Class.Binary.Field;
global using BinaryMaide = Class.Binary.Maide;
global using BinaryVar = Class.Binary.Var;
global using BinaryRead = Class.Binary.Read;
global using InfoGen = Class.Info.Gen;
global using PortPort = Class.Port.Port;
global using PortRead = Class.Port.Read;
global using PortImport = Class.Port.Import;
global using PortImportClass = Class.Port.ImportClass;
global using PortExport = Class.Port.Export;
global using TokenCreate = Class.Token.Create;
global using Code = Class.Token.Code;
global using TokenToken = Class.Token.Token;
global using TokenInfo = Class.Token.Info;
global using TokenResult = Class.Token.Result;
global using NodeCreate = Class.Node.Create;
global using NodeNode = Class.Node.Node;
global using NodeResult = Class.Node.Result;
global using Traverse = Class.Node.Traverse;
global using NodeClass = Class.Node.Class;
global using NodeField = Class.Node.Field;
global using NodeMaide = Class.Node.Maide;
global using NodeVar = Class.Node.Var;
global using Comp = Class.Node.Comp;
global using Part = Class.Node.Part;
global using NodeCount = Class.Node.Count;
global using Param = Class.Node.Param;
global using ClassName = Class.Node.ClassName;
global using FieldName = Class.Node.FieldName;
global using MaideName = Class.Node.MaideName;
global using VarName = Class.Node.VarName;
global using PrusateCount = Class.Node.PrusateCount;
global using ProbateCount = Class.Node.ProbateCount;
global using PrecateCount = Class.Node.PrecateCount;
global using PrivateCount = Class.Node.PrivateCount;
global using State = Class.Node.State;
global using Execute = Class.Node.Execute;
global using InfExecute = Class.Node.InfExecute;
global using WhileExecute = Class.Node.WhileExecute;
global using ReturnExecute = Class.Node.ReturnExecute;
global using ReferExecute = Class.Node.ReferExecute;
global using AreExecute = Class.Node.AreExecute;
global using OperateExecute = Class.Node.OperateExecute;
global using Argue = Class.Node.Argue;
global using Target = Class.Node.Target;
global using VarTarget = Class.Node.VarTarget;
global using SetTarget = Class.Node.SetTarget;
global using Operate = Class.Node.Operate;
global using GetOperate = Class.Node.GetOperate;
global using CallOperate = Class.Node.CallOperate;
global using ThisOperate = Class.Node.ThisOperate;
global using BaseOperate = Class.Node.BaseOperate;
global using NewOperate = Class.Node.NewOperate;
global using ShareOperate = Class.Node.ShareOperate;
global using CastOperate = Class.Node.CastOperate;
global using VarOperate = Class.Node.VarOperate;
global using ValueOperate = Class.Node.ValueOperate;
global using NullOperate = Class.Node.NullOperate;
global using BracketOperate = Class.Node.BracketOperate;
global using EqualOperate = Class.Node.EqualOperate;
global using AndOperate = Class.Node.AndOperate;
global using OrnOperate = Class.Node.OrnOperate;
global using NotOperate = Class.Node.NotOperate;
global using LessOperate = Class.Node.LessOperate;
global using AddOperate = Class.Node.AddOperate;
global using SubOperate = Class.Node.SubOperate;
global using MulOperate = Class.Node.MulOperate;
global using DivOperate = Class.Node.DivOperate;
global using SignLessOperate = Class.Node.SignLessOperate;
global using SignMulOperate = Class.Node.SignMulOperate;
global using SignDivOperate = Class.Node.SignDivOperate;
global using BitAndOperate = Class.Node.BitAndOperate;
global using BitOrnOperate = Class.Node.BitOrnOperate;
global using BitNotOperate = Class.Node.BitNotOperate;
global using BitLeftOperate = Class.Node.BitLeftOperate;
global using BitRightOperate = Class.Node.BitRightOperate;
global using BitSignRightOperate = Class.Node.BitSignRightOperate;
global using Value = Class.Node.Value;
global using BoolValue = Class.Node.BoolValue;
global using IntValue = Class.Node.IntValue;
global using IntHexValue = Class.Node.IntHexValue;
global using IntSignValue = Class.Node.IntSignValue;
global using IntHexSignValue = Class.Node.IntHexSignValue;
global using StringValue = Class.Node.StringValue;
global using ModuleCreate = Class.Module.Create;
global using ModuleResult = Class.Module.Result;
global using ModuleInfo = Class.Module.Info;
global using BuiltinClass = Class.Module.SystemClass;
global using Type = System.Type;
global using IEnumerable = System.Collections.IEnumerable;
global using IEnumerator = System.Collections.IEnumerator;
global using StringBuilder = System.Text.StringBuilder;
global using PropertyInfo = System.Reflection.PropertyInfo;
global using FieldInfo = System.Reflection.FieldInfo;
global using BindingFlags = System.Reflection.BindingFlags;
global using PropertyInfoDictionary = System.Collections.Generic.Dictionary<string, System.Reflection.PropertyInfo>;
global using IEnumerablePropertyInfo = System.Collections.Generic.IEnumerable<System.Reflection.PropertyInfo>;
global using FieldInfoDictionary = System.Collections.Generic.Dictionary<string, System.Reflection.FieldInfo>;
global using IEnumerableFieldInfo = System.Collections.Generic.IEnumerable<System.Reflection.FieldInfo>;
global using Path = System.IO.Path;
global using Directory = System.IO.Directory;