using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

internal static class UsbNotification
{
    public const int DbtDevicearrival = 0x8000; // system detected a new device        
    public const int DbtDeviceremovecomplete = 0x8004; // device is gone      
    public const int WmDevicechange = 0x0219; // device change event      
    private const int DbtDevtypDeviceinterface = 5;
    private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
    private static IntPtr notificationHandle;

    /// <summary>
    /// Registers a window to receive notifications when USB devices are plugged or unplugged.
    /// </summary>
    /// <param name="windowHandle">Handle to the window receiving notifications.</param>
    public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
    {
        DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
        {
            DeviceType = DbtDevtypDeviceinterface,
            Reserved = 0,
            ClassGuid = GuidDevinterfaceUSBDevice,
            Name = 0
        };

        dbi.Size = Marshal.SizeOf(dbi);
        IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
        Marshal.StructureToPtr(dbi, buffer, true);

        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
    }

    /// <summary>
    /// Unregisters the window for USB device notifications
    /// </summary>
    public static void UnregisterUsbDeviceNotification()
    {
        UnregisterDeviceNotification(notificationHandle);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

    [DllImport("user32.dll")]
    private static extern bool UnregisterDeviceNotification(IntPtr handle);

    [StructLayout(LayoutKind.Sequential)]
    private struct DevBroadcastDeviceinterface
    {
        internal int Size;
        internal int DeviceType;
        internal int Reserved;
        internal Guid ClassGuid;
        internal short Name;
    }


    /*
     * C:\Users\sizquierdo.ORBITA>C:\Users\sizquierdo.ORBITA\Desktop\WMI_Utility.exe /
 Win32_USBHub

 Building list of all WMI Win32 classes.

 Building data set for Win32_USBHub

 ------------ ----------------------------- -----------------------
  Type         Property Name                 Data
 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       SafeNet Inc. Sentinel HL Key
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   SafeNet Inc. Sentinel HL Key
  String       DeviceID                      ALADDIN\VID0529&PID0001&HASPHL\7&1
2D4A6D&1&00
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          SafeNet Inc. Sentinel HL Key
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   ALADDIN\VID0529&PID0001&HASPHL\7&1
2D4A6D&1&00
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Dispositivo compuesto USB
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Dispositivo compuesto USB
  String       DeviceID                      USB\VID_04F2&PID_B213\SN0001
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Dispositivo compuesto USB
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\VID_04F2&PID_B213\SN0001
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Generic USB Hub
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Generic USB Hub
  String       DeviceID                      USB\VID_8087&PID_0024\5&2213DED0&0
1
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Generic USB Hub
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\VID_8087&PID_0024\5&2213DED0&0
1
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Realtek USB 2.0 Card Reader
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Realtek USB 2.0 Card Reader
  String       DeviceID                      USB\VID_0BDA&PID_0138\200905163882
0000
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Realtek USB 2.0 Card Reader
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\VID_0BDA&PID_0138\200905163882
0000
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Generic USB Hub
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Generic USB Hub
  String       DeviceID                      USB\VID_8087&PID_0024\5&33BBE6DB&0
1
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Generic USB Hub
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\VID_8087&PID_0024\5&33BBE6DB&0
1
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       SafeNet Inc. USB Key
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   SafeNet Inc. USB Key
  String       DeviceID                      USB\VID_0529&PID_0001\6&34BF07AE&0
1
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          SafeNet Inc. USB Key
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\VID_0529&PID_0001\6&34BF07AE&0
1
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       SafeNet Inc. HASP Key
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   SafeNet Inc. HASP Key
  String       DeviceID                      USB\HASP\7&1E2D4A6D&1&00
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          SafeNet Inc. HASP Key
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\HASP\7&1E2D4A6D&1&00
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Concentrador raíz USB
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Concentrador raíz USB
  String       DeviceID                      USB\ROOT_HUB20\4&2098E145&0
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Concentrador raíz USB
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\ROOT_HUB20\4&2098E145&0
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  UInt16       Availability
  String       Caption                       Concentrador raíz USB
  UInt8        ClassCode
  UInt32       ConfigManagerErrorCode        0
  Boolean      ConfigManagerUserConfig       False
  String       CreationClassName             Win32_USBHub
  UInt8        CurrentAlternateSettings
  UInt8        CurrentConfigValue
  String       Description                   Concentrador raíz USB
  String       DeviceID                      USB\ROOT_HUB20\4&25A55E8B&0
  Boolean      ErrorCleared
  String       ErrorDescription
  Boolean      GangSwitched
  DateTime     InstallDate
  UInt32       LastErrorCode
  String       Name                          Concentrador raíz USB
  UInt8        NumberOfConfigs
  UInt8        NumberOfPorts
  String       PNPDeviceID                   USB\ROOT_HUB20\4&25A55E8B&0
  UInt16       PowerManagementCapabilities
  Boolean      PowerManagementSupported
  UInt8        ProtocolCode
  String       Status                        OK
  UInt16       StatusInfo
  UInt8        SubclassCode
  String       SystemCreationClassName       Win32_ComputerSystem
  String       SystemName                    01P0066
  UInt16       USBVersion

 ------------ ----------------------------- -----------------------
  Data sets:  9
 ------------ ----------------------------- -----------------------
     * 
     */ 
}