﻿using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication start acknowledge
    /// Description:
    ///     When accepting the communication start the controller sends as reply, 
    ///     a Communication start acknowledge. This message contains some basic information about the
    ///     controller, such as cell ID, channel ID, and name.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0002 : Mid, ICommunication
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 6;
        public const int MID = 2;

        public int CellId
        {
            get => RevisionsByFields[1][(int)DataFields.CELL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.CELL_ID].SetValue(_intConverter.Convert, value);
        }
        public int ChannelId
        {
            get => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].SetValue(_intConverter.Convert, value);
        }
        public string ControllerName
        {
            get => RevisionsByFields[1][(int)DataFields.CONTROLLER_NAME].Value;
            set => RevisionsByFields[1][(int)DataFields.CONTROLLER_NAME].SetValue(value);
        }
        //Rev 2
        public string SupplierCode
        {
            get => RevisionsByFields[2][(int)DataFields.SUPPLIER_CODE].Value;
            set => RevisionsByFields[2][(int)DataFields.SUPPLIER_CODE].SetValue(value);
        }
        //Rev 3
        public string OpenProtocolVersion
        {
            get => RevisionsByFields[3][(int)DataFields.OPEN_PROTOCOL_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.OPEN_PROTOCOL_VERSION].SetValue(value);
        }
        public string ControllerSoftwareVersion
        {
            get => RevisionsByFields[3][(int)DataFields.CONTROLLER_SOFTWARE_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.CONTROLLER_SOFTWARE_VERSION].SetValue(value);
        }
        public string ToolSoftwareVersion
        {
            get => RevisionsByFields[3][(int)DataFields.TOOL_SOFTWARE_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.TOOL_SOFTWARE_VERSION].SetValue(value);
        }
        //Rev 4
        public string RBUType
        {
            get => RevisionsByFields[4][(int)DataFields.RBU_TYPE].Value;
            set => RevisionsByFields[4][(int)DataFields.RBU_TYPE].SetValue(value);
        }
        public string ControllerSerialNumber
        {
            get => RevisionsByFields[4][(int)DataFields.CONTROLLER_SERIAL_NUMBER].Value;
            set => RevisionsByFields[4][(int)DataFields.CONTROLLER_SERIAL_NUMBER].SetValue(value);
        }
        //Rev 5 
        public SystemType SystemType
        {
            get => (SystemType)RevisionsByFields[5][(int)DataFields.SYSTEM_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[5][(int)DataFields.SYSTEM_TYPE].SetValue(_intConverter.Convert, (int)value);
        }
        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)RevisionsByFields[5][(int)DataFields.SYSTEM_SUBTYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[5][(int)DataFields.SYSTEM_SUBTYPE].SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 6
        public bool SequenceNumberSupport
        {
            get => RevisionsByFields[6][(int)DataFields.SEQUENCE_NUMBER_SUPPORT].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[6][(int)DataFields.SEQUENCE_NUMBER_SUPPORT].SetValue(_boolConverter.Convert, value);
        }
        public bool LinkingHandlingSupport
        {
            get => RevisionsByFields[6][(int)DataFields.LINKING_HANDLING_SUPPORT].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[6][(int)DataFields.LINKING_HANDLING_SUPPORT].SetValue(_boolConverter.Convert, value);
        }

        public MID_0002(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 1)</param>
        public MID_0002(int cellId, int channelId, string controllerName, int revision = 1) : this(revision)
        {
            CellId = cellId;
            ChannelId = channelId;
            ControllerName = controllerName;
        }

        /// <summary>
        /// Revision 2 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, int revision = 2)
            : this(cellId, channelId, controllerName, revision)
        {
            SupplierCode = supplierCode;
        }

        /// <summary>
        /// Revision 3 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 3)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, int revision = 3)
            : this(cellId, channelId, controllerName, supplierCode, revision)
        {
            OpenProtocolVersion = openProtocolVersion;
            ControllerSoftwareVersion = controllerSoftwareVersion;
            ToolSoftwareVersion = toolSoftwareVersion;
        }

        /// <summary>
        /// Revision 4 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType,
            string controllerSerialNumber, int revision = 4)
            : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion,
                  toolSoftwareVersion, revision)
        {
            RBUType = rbuType;
            ControllerSerialNumber = controllerSerialNumber;
        }

        /// <summary>
        /// Revision 5 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="systemType">The system type of the controller. 3 ASCII digits</param>
        /// <param name="systemSubType">The system subtype. 3 ASCII digits</param>
        /// <param name="revision">Revision number (default = 5)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType,
            string controllerSerialNumber, SystemType systemType, SystemSubType systemSubType, int revision = 5)
            : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion,
                  toolSoftwareVersion, rbuType, controllerSerialNumber, revision)
        {
            SystemType = systemType;
            SystemSubType = systemSubType;
        }

        /// <summary>
        /// Revision 6 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="systemType">The system type of the controller. 3 ASCII digits</param>
        /// <param name="systemSubType">The system subtype. 3 ASCII digits</param>
        /// <param name="sequenceNumberSupport">Flag sequence number handling supported if = 1</param>
        /// <param name="linkHandlingSupport">Flag linking functionality handling supported if = 1.</param>
        /// <param name="revision">Revision number (default = 6)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType,
            string controllerSerialNumber, SystemType systemType, SystemSubType systemSubType, bool sequenceNumberSupport, bool linkingHandlingSupport, int revision = 6)
            : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion,
                  toolSoftwareVersion, rbuType, controllerSerialNumber, systemType, systemSubType, revision)
        {
            SequenceNumberSupport = sequenceNumberSupport;
            LinkingHandlingSupport = linkingHandlingSupport;
        }

        internal MID_0002(IMid nextTemplate) : this(LAST_REVISION) => NextTemplate = nextTemplate;

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            //Rev 1
            if (CellId < 0 || CellId > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(CellId), "Range: 0000-9999").Message);
            if (ChannelId < 0 || ChannelId > 20)
                failed.Add(new ArgumentOutOfRangeException(nameof(ChannelId), "Range: 00-20").Message);
            if (ControllerName.Length > 25)
                failed.Add(new ArgumentOutOfRangeException(nameof(ControllerName), "Max of 20 characters").Message);

            if (HeaderData.Revision > 1) //Rev 2
            {
                if (SupplierCode.Length > 3)
                    failed.Add(new ArgumentOutOfRangeException(nameof(SupplierCode), "Max of 3 characters").Message);

                if (HeaderData.Revision > 2) //Rev 3
                {
                    if (OpenProtocolVersion.Length > 19)
                        failed.Add(new ArgumentOutOfRangeException(nameof(OpenProtocolVersion), "Max of 19 characters").Message);
                    if (ControllerSoftwareVersion.Length > 19)
                        failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSoftwareVersion), "Max of 19 characters").Message);
                    if (ToolSoftwareVersion.Length > 19)
                        failed.Add(new ArgumentOutOfRangeException(nameof(ToolSoftwareVersion), "Max of 19 characters").Message);

                    if (HeaderData.Revision == 4) //Rev 4
                    {
                        if (RBUType.Length > 24)
                            failed.Add(new ArgumentOutOfRangeException(nameof(RBUType), "Max of 24 characters").Message);
                        if (ControllerSerialNumber.Length > 10)
                            failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSerialNumber), "Max of 10 characters").Message);
                    }
                }
            }
            errors = failed;
            return errors.Any();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0'),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0'),
                                new DataField((int)DataFields.CONTROLLER_NAME, 30, 25, ' ')
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SUPPLIER_CODE, 57, 3, ' ')
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.OPEN_PROTOCOL_VERSION, 62, 19, ' '),
                                new DataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION, 83, 19, ' '),
                                new DataField((int)DataFields.TOOL_SOFTWARE_VERSION, 104, 19, ' ')
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.RBU_TYPE, 125, 24, ' '),
                                new DataField((int)DataFields.CONTROLLER_SERIAL_NUMBER, 151, 10, ' ')
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SYSTEM_TYPE, 163, 3, '0'),
                                new DataField((int)DataFields.SYSTEM_SUBTYPE, 168, 3, '0')
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SEQUENCE_NUMBER_SUPPORT, 173, 1),
                                new DataField((int)DataFields.LINKING_HANDLING_SUPPORT, 176, 1)
                            }
                }
            };
        }

        public enum DataFields
        {
            //Rev 1
            CELL_ID,
            CHANNEL_ID,
            CONTROLLER_NAME,
            //Rev 2
            SUPPLIER_CODE,
            //Rev 3
            OPEN_PROTOCOL_VERSION,
            CONTROLLER_SOFTWARE_VERSION,
            TOOL_SOFTWARE_VERSION,
            //Rev 4
            RBU_TYPE,
            CONTROLLER_SERIAL_NUMBER,
            //Rev 5
            SYSTEM_TYPE,
            SYSTEM_SUBTYPE,
            //Rev 6
            SEQUENCE_NUMBER_SUPPORT,
            LINKING_HANDLING_SUPPORT
        }
    }
}
