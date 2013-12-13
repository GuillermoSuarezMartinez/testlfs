<?xml version="1.0" encoding="utf-8"?>
<styleLibrary office2007CustomBlendColor="">
  <annotation>
    <lastModified>2012-01-19T15:06:58</lastModified>
  </annotation>
  <colorCategories>
    <colorCategory name="Primary Color" />
    <colorCategory name="Secondary Color" />
  </colorCategories>
  <styleSets defaultStyleSet="Default">
    <styleSet name="Default" viewStyle="OfficeXp" useOsThemes="False" useFlatMode="True">
      <componentStyles>
        <componentStyle name="Inbox Form">
          <properties>
            <property name="BackColor" colorCategory="{Default}">White</property>
          </properties>
        </componentStyle>
        <componentStyle name="Inbox ListBox">
          <properties>
            <property name="Font" colorCategory="{Default}">Segoe UI, 8.25pt</property>
          </properties>
        </componentStyle>
        <componentStyle name="Inbox MonthCalendar">
          <properties>
            <property name="TitleBackColor" colorCategory="{Default}">Red</property>
          </properties>
        </componentStyle>
        <componentStyle name="Inbox Panel">
          <properties>
            <property name="BackColor" colorCategory="{Default}">White</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraCalculator" buttonStyle="FlatBorderless" useOsThemes="False" useFlatMode="True">
          <properties>
            <property name="ImageTransparentColor">Transparent</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraDockManager" buttonStyle="FlatBorderless" useOsThemes="False" useFlatMode="True">
          <properties>
            <property name="CaptionGrabHandleStyle" colorCategory="{Default}">None</property>
            <property name="GroupPaneTabStyle" colorCategory="{Default}">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraExplorerBar" viewStyle="Standard" useOsThemes="False" />
        <componentStyle name="UltraListView" headerStyle="Standard" />
        <componentStyle name="UltraPictureBox" resolutionOrder="None" />
        <componentStyle name="UltraTabbedMdiManager">
          <properties>
            <property name="TabStyle" colorCategory="{Default}">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraTabControl" buttonStyle="FlatBorderless" useOsThemes="False" useFlatMode="True">
          <properties>
            <property name="ImageTransparentColor" colorCategory="{Default}">Transparent</property>
            <property name="Style" colorCategory="{Default}">Flat</property>
            <property name="UseHotTracking" colorCategory="{Default}">True</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraTabStripControl">
          <properties>
            <property name="Style" colorCategory="{Default}">Flat</property>
            <property name="UseHotTracking" colorCategory="{Default}">True</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraToolbarsManager" useOsThemes="False" useFlatMode="True" />
      </componentStyles>
      <styles>
        <style role="Base">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="DimGray" fontName="Segoe UI" textVAlign="Middle" fontSize="8" themedElementAlpha="Transparent" />
          </states>
        </style>
        <style role="Button" buttonStyle="FlatBorderless">
          <states>
            <state name="Normal">
              <resources>
                <name>Blank</name>
              </resources>
            </state>
            <state name="HotTracked" colorCategory="Primary Color" foreColor="Red" />
            <state name="Pressed">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="CalendarComboControlArea">
          <states>
            <state name="Normal" borderColor="LightGray" />
          </states>
        </style>
        <style role="ComboDropDownButton">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="HotTracked" colorCategory="Primary Color" backColor="Transparent" foreColor="White" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKQEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkklEQVQ4T6WT0Q2AIAxEbwPdRDeCDRxNN3EER3CE2gMbhUhU+GgItO8ocEBEkATgBVg0dg3NhpFzn9deIDBqwXYChJ6C+dFEIhxB26kE2jrrggDB/gd4F+gJTy+tljqZCK+V8Er47YzFfDPc1HbThXWVT9WZSYYfAjTJEE1i3ubCN3sGMIUvEacic/YxOHf5xzgAc6KsGgslADAAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="DayViewAllDayEventArea">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DayViewControlArea">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DayViewTimeSlotNonWorkingHour">
          <states>
            <state name="Normal" backColor="WhiteSmoke" borderColor="Gainsboro" backGradientStyle="None" />
            <state name="Selected" backColor="228, 242, 248" foreColor="White" borderColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DayViewTimeSlotWorkingHour">
          <states>
            <state name="Normal" backColor="WhiteSmoke" borderColor="Gainsboro" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="White" foreColor="White" borderColor="Gainsboro" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DesktopAlertButton">
          <states>
            <state name="Normal" colorCategory="{None}" borderColor="Transparent" />
            <state name="HotTracked" colorCategory="{None}" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" borderColor3DBase="Transparent" backHatchStyle="None" borderColor2="Transparent" />
          </states>
        </style>
        <style role="DesktopAlertCloseButton">
          <states>
            <state name="Normal" foreColor="Gray" />
            <state name="HotTracked" colorCategory="{None}" foreColor="White" borderColor="Transparent">
              <resources>
                <name>Circle2</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DesktopAlertControlArea">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DesktopAlertDropDownButton">
          <states>
            <state name="Normal" foreColor="Gray" />
            <state name="HotTracked">
              <resources>
                <name>Circle2</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DesktopAlertGripArea">
          <states>
            <state name="Normal">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DesktopAlertPinButton">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA3gAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAAA4IBgAAACYvnIoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAR0lEQVQ4T2P4//8/AyWYIs0gi2lnQFpa2n90jM2rOF0A0oysAZ0PkxuuBmALQJgYekASjEZcgUcwEGEKBt4AQvmEYBgQMgAAvPOLKy3LDAUAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="Primary Color" backColor="Transparent" foreColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAATwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAAA4IBgAAACYvnIoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAuElEQVQ4T52TgQ2EMAhF/wZ2E91IN3C0u00cwREcgYNWrAWaeJoQ05b/ChRARHAGLAR82Q429sh/WS/WtxUDEzvtp0iEkcn5pKAKKGK9sScmSkkjypACAJIT84H72ojksqSA1YUr6rvArsvZqoDtJWBTgM/5WQTnE0bV/hPQphAVUPfay64UfBHVMS6epnwVcej2QB8gzzjcG2kMIRZQG2msjaTzAAjkSStnsQdU0MygjxkmWc92mH4ZvQQRw3YqJQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="DockAreaSplitterBarHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>SplitterBarVertical</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockAreaSplitterBarVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>SplitterBarHorizontal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockControlPane">
          <states>
            <state name="Normal" foreColor="DimGray" />
          </states>
        </style>
        <style role="DockControlPaneContentArea">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DockFloatingWindowCaptionHorizontal">
          <states>
            <state name="Normal" backColor="255, 200, 90" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DockPaneCaption">
          <states>
            <state name="Normal">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockPaneCaptionHorizontal">
          <states>
            <state name="Normal" foreColor="White" />
            <state name="Active" foreColor="White" />
          </states>
        </style>
        <style role="DockPaneCloseButton">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="White" />
            <state name="HotTracked" colorCategory="Primary Color" foreColor="241, 0, 0" imageBackgroundStyle="Centered">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAAA4IBgAAACYvnIoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlElEQVQ4T62Tiw2AIAwF2UA30Y10A0fTTRyBERwBe40lBEMIIkmD/byrSHUhBJfZKv4hdomx2PGJ57UuDcxS4B9RaSNPXdTZA0HrWGFoXYQAGBvEBgeCTo+w1VoW8ugUcH4EoFNAz/oH0H2E7o84fLxGdHESpwYIM0C9DmE6ygR95UrIR3EOMNgiiT15IzriE3/9TDeWMECi7hDiIQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="DockPanePinButton">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="White" />
            <state name="HotTracked" colorCategory="Primary Color" foreColor="241, 0, 0">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAJAEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAjUlEQVQ4T6WTiw2AIAwF2QA30Y10A0bTTRiBERwBe8QaICFEIGlIP/fa8DExRlPZIf4ldoux2PGJF7W5s0kyvEBrI09d4hQmoJ06fKpLAsDLD1CFEViAXa9VI++A/SDsgYfXNDw19tSB2cGrsvpI1h8C3DH13wtDhEDoHD35BNawTrFL4swmoRM+8eJjPFvxFsw8r4RVAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="DockSlidingGroupHeaderHorizontal">
          <states>
            <state name="Normal" foreColor="White" fontBold="True">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
            <state name="HotTracked" borderColor="Transparent" />
          </states>
        </style>
        <style role="DockSlidingGroupHeaderVertical">
          <states>
            <state name="HotTracked" backColor="210, 210, 210" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DropDownButton">
          <states>
            <state name="Normal" colorCategory="Primary Color">
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
            <state name="HotTracked" colorCategory="Primary Color" foreColor="White" borderColor="Transparent" borderColor3DBase="Transparent" borderColor2="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKQEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkklEQVQ4T6WT0Q2AIAxEbwPdRDeCDRxNN3EER3CE2gMbhUhU+GgItO8ocEBEkATgBVg0dg3NhpFzn9deIDBqwXYChJ6C+dFEIhxB26kE2jrrggDB/gd4F+gJTy+tljqZCK+V8Er47YzFfDPc1HbThXWVT9WZSYYfAjTJEE1i3ubCN3sGMIUvEacic/YxOHf5xzgAc6KsGgslADAAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="EditorButton">
          <states>
            <state name="Normal" colorCategory="Primary Color">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKQEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkklEQVQ4T6WT0Q2AIAxEbwPdRDeCDRxNN3EER3CE2gMbhUhU+GgItO8ocEBEkATgBVg0dg3NhpFzn9deIDBqwXYChJ6C+dFEIhxB26kE2jrrggDB/gd4F+gJTy+tljqZCK+V8Er47YzFfDPc1HbThXWVT9WZSYYfAjTJEE1i3ubCN3sGMIUvEacic/YxOHf5xzgAc6KsGgslADAAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" foreColor="White" />
          </states>
        </style>
        <style role="EditorControl">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ExplorerBarControlArea">
          <states>
            <state name="Normal" backColor="232, 244, 249" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ExplorerBarGroupHeader">
          <states>
            <state name="Normal" borderColor="Transparent" borderAlpha="Transparent" fontBold="True">
              <resources>
                <name>RedForeground</name>
                <name>buttonBorder</name>
              </resources>
            </state>
            <state name="HotTracked" borderAlpha="Transparent">
              <resources>
                <name>BottonBorderRed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ExplorerBarGroupItemAreaInner">
          <states>
            <state name="Normal" borderColor="Transparent" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="2, 1, 2, 2" />
          </states>
        </style>
        <style role="ExplorerBarGroupItemAreaOuter">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ExplorerBarItem">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="DimGray" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>blueWhite</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="Red" borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="5, 2, 7, 4" />
            <state name="Active" foreColor="241, 0, 0" fontBold="True" />
          </states>
        </style>
        <style role="ExplorerBarNavigationOverflowButtonArea">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridAddNewBoxButton">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridCaption">
          <states>
            <state name="Normal" backColor="WhiteSmoke" borderColor="Transparent" imageBackgroundStyle="Stretched" fontBold="True" fontSize="11" backGradientStyle="None" imageBackgroundStretchMargins="0, 0, 0, 2">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxwAAAAKJUE5HDQoaCgAAAA1JSERSAAAAIAAAABMIBgAAAPGUD/cAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAMElEQVRIS+3QMQ0AAAwCQfwbww0WaKqC5QfmJ6ckXU7L+Lc5gAACCCCAAAIIyHaXO4rc7zmUQQpQAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridCell">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="HotTracked" borderColor="Transparent" />
            <state name="Active" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="EditMode" backColor="180, 180, 180" foreColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="3, 2, 2, 2" />
          </states>
        </style>
        <style role="GridColumnHeader">
          <states>
            <state name="Normal" textHAlign="Center" imageBackgroundStyle="Stretched" fontBold="True" fontSize="8" imageBackgroundStretchMargins="6, 3, 7, 7">
              <resources>
                <name>GridHeader</name>
                <name>BlackForeground</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>BottonBorderRed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridControlAreaBase">
          <states>
            <state name="Normal" backColor="White" borderColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridGroupByBox">
          <states>
            <state name="Normal" backColor="Gainsboro" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridGroupByBoxPrompt">
          <states>
            <state name="Normal" backColor="Gainsboro" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridHeader" borderStyle="None" />
        <style role="GridRow">
          <states>
            <state name="Normal" backColor="White" borderColor="Gainsboro" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="WhiteSmoke" foreColor="15, 15, 15" backGradientStyle="None" backHatchStyle="None" />
            <state name="HotTracked">
              <resources>
                <name>blueWhite</name>
              </resources>
            </state>
            <state name="Active" colorCategory="Primary Color" backColor="Transparent" foreColor="Red" imageBackgroundStyle="Stretched" fontBold="True" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 2, 0, 2">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAABwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMwAAAB4IBgAAAIGTJsIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAcElEQVRYR+3YwQ0AMQgDQfdfMQlJfEcXaAXSFjDyD1kyJVEg5VBEmNJgui6ptZYpDabrkqxl9t6mJAqkHCxMZpqSKJBysDDnHFMSBVIOFubea0qiQMrBwrz3TEkUSDkG03XN/wPIucF03ZL1niX9mj9kUASY95Iv4AAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="GridRowSelector">
          <states>
            <state name="Normal" backColor="WhiteSmoke" borderColor="WhiteSmoke" imageHAlign="Right" imageVAlign="Middle" backGradientStyle="None">
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
            <state name="FilterRow" backColor="IndianRed" backGradientStyle="None" />
          </states>
        </style>
        <style role="GridRowSelectorHeader">
          <states>
            <state name="Normal" backColor="WhiteSmoke" backGradientStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemAreaHorizontalBottom">
          <states>
            <state name="Normal" colorCategory="Primary Color" borderColor="Transparent" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 4, 0, 0">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxAAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAB0IBgAAAEyvh4EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAALUlEQVRIS2P4z8Dwn1IMNIFyMGoIZhiOhslomBCTs0bTyWg6GU0nxITAsE8nAHGqitjYylA0AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="GroupPaneTabItemAreaVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GroupPaneTabItemAreaVerticalRight">
          <states>
            <state name="Normal" colorCategory="Primary Color" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="3, 0, 0, 0">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxQAAAAKJUE5HDQoaCgAAAA1JSERSAAAAHQAAABEIBgAAACFRp3QAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAALklEQVRIS2P4z8Dwn96AYdRSWgb5aPDSMnT/jwbvaPBSJQRGExJVghGXISMneAGak4rYoa3TAgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="GroupPaneTabItemHorizontalBottom">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="6, 4, 6, 5" />
          </states>
        </style>
        <style role="GroupPaneTabItemHorizontalTop">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemVerticalRight">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="Link">
          <states>
            <state name="Normal" textVAlign="Top" />
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ListViewColumnHeader">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ListViewControlArea">
          <states>
            <state name="Normal" borderColor="Gainsboro" />
          </states>
        </style>
        <style role="ListViewGroupHeader">
          <states>
            <state name="Normal">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ListViewItem">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="Selected">
              <resources>
                <name>BackgroundRed</name>
              </resources>
            </state>
            <state name="HotTracked" foreColor="228, 0, 0" />
          </states>
        </style>
        <style role="MainMenubarHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MaskPromptChar">
          <states>
            <state name="Normal" borderColor="Silver" />
          </states>
        </style>
        <style role="MenuCheckMark">
          <states>
            <state name="Normal">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemAddRemoveTool">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" />
          </states>
        </style>
        <style role="MenuItemButton">
          <states>
            <state name="HotTracked" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>RedForeground</name>
                <name>buttonBorder</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemComboBox">
          <states>
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemMaskedEdit">
          <states>
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemMdiWindowListItem">
          <states>
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemPopupColorPicker">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="HotTracked" borderColor="DarkGray">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemPopupControlContainer">
          <states>
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuItemPopupMenu">
          <states>
            <state name="HotTracked">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MenuSideStrip">
          <states>
            <state name="Normal">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MonthViewMultiMonthScrollButton">
          <states>
            <state name="Normal">
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="NavigationToolbarBackButton">
          <states>
            <state name="Normal" colorCategory="Primary Color" imageBackgroundStyle="Centered">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAzwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABOElEQVQ4T5WTQU7CQBSG3xFYsoMDsOEInIWzsMYb9AAcghVb0hAW1UhtiSjWUqMRU6rJ7/9qx0ynNIEmX9I3//+/zkxeBYDY3Iv0yQ0JCCr0Xdf6rr8WDmki2LSgmnrsJv8NIpHVAw2XoF7TpGywFZnGDF+DZjQrO56L4LGFo+ed1TSjWXkW8Z5YuOw7HZzmc34EDc14NSsvvO09G9QYDHAMgjKsT0Ov/JqVVxY229EIm+USSZIgz/Oygeuxazmwgc3deAzf9xGGIdI0RVEUNd31yxu3QWCzGw6xXiwQRRGyLKtpjjeQd17EBxu4HLpd3M5miOO4oRmvZuVTpEfQRjyZtGqaLQfpi0NBcCV/g2RGMud4nlhegnpro2yKgjsh+G5BNfWc/ZnM4g/PRaYkIKjQd13rub/zL/ckKpSSgXO7AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
              <imageBackgroundDisabled>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAJAIAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABjUlEQVQ4T41TTWrCQBgd6AHsyoIbu+i2lKzc9QAF9z1AT9CNG/deoVs3bsWlkBsUS6QUbJWgtdIiGn+Smhij0/dCp4whFQMvzHzvJzOTb4SUUujoCXECZIaGkfsoFM4Jjlkjl9TvmW2IvorFC6dcvppVKoYO1shRo4f8BQyz2TOnVLqcw3gI1FCrQuKAd6TOQSxgPgbU0kOvGGFfUyzNhTkNO9dtpNXpoVd8CnHqYn8eAnT4tdr1zvcf8RWZ5Dinh14xxQl/o6DDMc1b3/NGNPNJ8mpOr5gZRn6FAIW3ZvO+1+0ux+OxDIIgDtB5fUyvmOPlI0DhyTQfLMuStm3LyWQiwzCUOq+P6RVLLCMp6NTrd8/t9rLf70vHcf4NoFcscBABDiTAKnQMq9WbF8vqDAYDmeTiOTz0Cg+/wscvCVFMw2ur1Uir00Nv3EgrNEWI5tgg5BhQS0/cSKol12jPDYgIIYdADbV7rawmIVIjLC3C/rYI0sEaOWpSL5MqRtgXkNnihIH8L3KskUte5x/UokB1f3S+OgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackgroundDisabled>
            </state>
            <state name="HotTracked" colorCategory="Primary Color">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA/QEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABZklEQVQ4T42Tv0rDYBTF7yN07FYfoEsfoc/SzdnFxa2gUxXcBDNL3cRNrQgFF0tqHVKUmGj9Qw0FqWgIwvWcaOTL15S28Cvfveecmz/ciKqKyZ3ICti+EPHORJTwzB41258L+zC1EVgHqxbsUaPHHPI/wBO53oRhbQH00JsNSQc8iLR2IGwsCb3MMCtPeK5TNLbmMHCcQo0ZZuVFxNlHsWuxVyrpqNPBRXRGo5cZZmWIN8zC5LBa1cjz0jB/tp7VzMotwgcGx/W6Dns9HY/HGsdxOsDUzTOzco+/I4OTRkNd11Xf9zWKIk2SJKebXmZlZCxMtjjntZr2u10NgkAnk0m6TEUwK+94EVcwXNqUy9pvtzUMw1kNXmaYlQ+RyjOKwRxums1CjRlm00X6xFI8/q7pUtDLTLpI2Up+YT3fUL4ugB56c6ucFQmmQuSt6dSCPWr0FH5MWfMbzwVawAP6B8/sVezP+Qd2eAaa6xW/PAAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="Pressed" colorCategory="Primary Color">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAACQIAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABcklEQVQ4T42TsUrDYBSF7yN07KYP0KWP0GfpIIIIIogooigRBbHiIIhDdjs5uFpQCl2swaEGlJAoViglKIiUIFzPCUb+/I20ha/Jf885t83lRlRVTJ5EZsHRtYh/JaKE96xRs/25cADTOQIrYM6CNWr0mE3+GjyI3G/CMD8BeujNmqQNnkUa2xAWpoReZpiVVzzXBQqL/9Bx3UKNGWblTcTdwmHJYq1U0sdWCz+iYxq9zDArd5jwMg4m+5WK9n0/DfNj69mZWen+Tp1TJse1mva6XR0MBjoajdIGmWZfmRUPX6sGbr2unudpEAQ6HA41SZKcbnqZlR7+xjpuTA6rVb1ttzUMQ43jOKeZPmblA4M4QIMNi91yWW+aTY2iaEyjlxlm5VNkBquaTrWIS8cprDPDbLpIX1iKUxR2poReZtJFylbyHet5hqMzAXroza1ydkjQtQPDCdizYI0aPYUvU1b8xnOBxgsmHCJAeM8aNft1/gEIs+aTrE7KDAAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="NavigationToolbarButtonArea">
          <states>
            <state name="Normal" colorCategory="{None}" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsgIAAAKJUE5HDQoaCgAAAA1JSERSAAAAMwAAABUIBgAAAOtU1gEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAACG0lEQVRYR9WY6YriUBCF85JOv8Uw79P9Ju4rLkTcFTfcUcEWFVtFsLq+O8Rxenr+JZj8OFwXuHVOao8lIpaDcDhsOUin0/FoNHrT7+IXwAdejzwf+f8jJJfL/YrFYtdEIiHlclnq9bo0Go2nAx62bUs8Hhf4wdMR5QgyYpwfs9nsWyQSkVKpJK1Wy7coFosCT/g+CrqLUaVveIMn0Ol0fI9arYaHRHm/IginGK8UCoUX8gIh3W43MKhWq8ZDyv8HOoyYVCq1JbT6/X7gkM/nBf5GjIp40Sohg8FAhsNh4NDr9Yx30GFpzNnqJhmNRoGFaiB3bELso91uy2QycR3k4W63M32K0wsb3Emuo4OcMUZms5nrwP37/d6EAacXNriT9ECHETOfz2WxWLgOcvFwOIhzemGDO6fT6R8xqFutVq6Dbn08Hk3X5vTCBneOx+PfYnTW+aAkr9dr1/FVjBc2uJOcR4elo4GOPLZsNhvXkUwm5XQ6iXN6YYM7GW/QYelYEGKMwV3b7TZwWC6XZqzRihYyE4DW6HcmY8pn0FCpVOgx7/dxptlshohvCgHVJygg8fEK/O9i+KDh9ko/wG1UHr+DBw9feDtrwF/7DH+QP0zONDmS12+AFysKkfQoxKwAX1dmXcp+apm76uJjmuj5fJbL5fJ08FBpjplMhjJ8hee3m+Z37wB0V1Dx8RuufDacdxAaNTflFfvfO4BPWKHPKkkq5X0AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
          </states>
        </style>
        <style role="NavigationToolbarForwardButton">
          <states>
            <state name="Normal" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAvgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABJ0lEQVQ4T5WTUW6CUBBFZwl++4Mr8MstuBdXo90By/DTPfBFYgu1UYuKEJu2QTC5vaO+BmVIlOQk783ce3m8DAJA6ryK9MgLCQmu6FprvXv9jTmiiOCtBe2pph7yH/AuEsQUPIJqXcg54ENksqD5GdSjXlnxuwiWBj++b9ZVqx71yqeIv+bGgm/AcTZD0umYffXKhredMMBCA/Q5xTF2/X5Do17Z0dyGCyiKAtv5HOvhsKGVPQPa0ICyLJGmKaIoQjwaNbSS8xgEFlVVIcsyLIIAyWBgaUI58CK+GGCR5zmW0ymybtfsq1e+RTwCi814bNZrWu88SL8cCoInuQySG8mC43nk9hFUezPKblPyJARVC9pTjfkzueKJd0ImJCS4omutefe/8x8GWyyroHmjnwAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
              <imageBackgroundDisabled>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAFwIAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABgElEQVQ4T42TsU7CUBiF/8QHwAkTFhxcjenE5gOYsPsAPoELCzuv4BPAzMIDkG7uxBApBGhEAy1QpLUtXM9prCnXSiA5pP3/853ee/tXlFKS1avIGVSYGEZpWqlcUrxmjT3dfwBbMM2q1SunXr9xGw0jK9bYoycb8hswKRYvnFrtegnwmOihNw1JAsZIXaKxAnyK6CVDVmzsa4GleYB17T2vnVdnjQxZeRM597C/DYq68AS19/1nv9m81XtkyMoCJ/wJOE8MSH5xbG9N8173kBXXMMpbBOQp5YMgUB+z2Xra7T5mfWRliT8fAXliQBiGaj6fK8uyVM80n7I+srLGMv4LiKJIOY6jRsPhetTpPOg+srLCQQQ4kACr0OW6rhoPBi/vrdbdnz4YsrLBq/DxSkIE6LL7/XZenTUyZJNB2mIoQgxHhMYpopdMMkjpSH5hPCM0YoQcEz30HoxyehMiNcbSYuxvh6CsWGOPntyPKS3G2BdU2OGEofKPSqyxp3/O35KkQuYfjVA+AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackgroundDisabled>
            </state>
            <state name="HotTracked" colorCategory="Primary Color">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9QEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABXklEQVQ4T42TvUrDcBTF7yN07lKfoFNfoe9SnF1cnHVpFdwEM4uDg0Nx0KIuOrikS6Q1Aa1VMKRIRUMiXM+J/iUf/9IWfk3uvefcfHAiqip5xiJrYPdKxLsQUcJz9jgr6wtmH6JjGDbBegn2OKMmv+R/gSfibkOwsQRqqDVLsgWPIr09DLZWhFp66JVnPNc5GjsWho5j7VNLD73yIuIcoti3gCvoZDDQg1qtMqeHXrnHG2Zhgwv4mweBnjSbFQ29MoL5aAFmQRzHOh2N9KzdLmjplQB/pwvggiRJNAxD9X1fLzudgpZemeQCY4JjjmmaahRF6ruuXrdaWajy0CvveBF3GNxYmM1mOu739bZer8zpoVc+RBpTFEMLD92utU8tPfRmQfpEKJ5+Y7oS1NKTBclE8gvxfEP5ugRqqC1E2RQJtmLIW9N5CfY4o8b6MZnmN54L9IAH9A+es9cof84/bDAIsjZnetIAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
            <state name="Pressed" colorCategory="Primary Color">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA/QEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAABAIBgAAAB/z/2EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABZklEQVQ4T42TsUrDYBSF7yN07qJP0Kmv0GexgggiiCiiKKJDaTsVxCGLk5tTtxacOlXJoGIkFYu4xKSCSEmE6znBSPPnl7bwlf+/95zT5nIjqiqzPIksg/a1yENPRAnPrLFn6nNmH6JLGLbAigFr7FEzG/IXcC/i7kOwOgdqqM1C0oAXkdYhGmsLQi099MornusKhXULA8ex1qmlh155E3EOcNmwgF9Qr9/XnVKp0KeHXrnBhDdxscEAft5HI21UKgUNvTL8nTqnbJIFTKdTHXuedmq1nIZeucXX9j8wII5jDYJAfd/Xi3o9p6VX7vA3dnGwkSSJhmGoj66r7Wq1oKFXPjCIBgL2LERRpMNuV0/K5UKfHnrlU2QJq6qcqkmv2bTWqaOH3nSRvrAUZygcLQi19KSLlK3kBOt5juvxHKihNrfK2SVG6gCCDjg1YI09aqwvU1b8xnOB1hgTfoaB8Mwae+br/APkduiqPsVOsQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="NavigationToolbarRecentHistoryButton">
          <states>
            <state name="Normal" imageHAlign="Right" imageVAlign="Middle">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAzQAAAAKJUE5HDQoaCgAAAA1JSERSAAAADQAAAA4IBgAAAPR/ltIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAAANklEQVQoU2P4//8/A6mYZA0gC4a9po8MDMFAfA8Nd6GHLkZAoGnE0IAz9KAasWoYEUFObMIFALEbDzhpA2E0AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
            </state>
            <state name="HotTracked">
              <resources>
                <name>HistoryButtn</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>HistoryButtn</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="PopupMenu">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="ProgressBarFill">
          <states>
            <state name="Normal" foreColor="White" fontBold="True">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAHwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMwAAAB4IBgAAAIGTJsIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAiElEQVRYR93YUQpBARQG4dn/DhERIroiRMQ1tjEP33mf/rfDFMYKZsZUMDemgoUxFSyNqWBlTAVrYyrYGFPB1pgKdsZUsDemgoMxFRyNqWAwpoKTMRWcjangYkwFV2MquBlTwd2YCh7GVPA0poKXMRW8jangY0wFX2MqGI2paC1T+TP/O5h4Kn5ReHckUQzzoQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScheduleAppointment">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
            <state name="Selected" backColor="Transparent" fontBold="True" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleCurrentDayHeader">
          <states>
            <state name="Normal">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleDay">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="DimGray" borderColor="Gainsboro">
              <resources>
                <name>blueWhite</name>
              </resources>
            </state>
            <state name="Selected" backColor="253, 0, 0" foreColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScheduleDayHeader">
          <states>
            <state name="Normal" fontBold="True">
              <resources>
                <name>RedForeground</name>
                <name>background</name>
              </resources>
            </state>
            <state name="Selected" foreColor="White" imageBackgroundStyle="Stretched" fontBold="True">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
            <state name="Active" imageBackgroundStyle="Stretched" />
          </states>
        </style>
        <style role="ScheduleDayOfWeekHeader">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="60, 60, 60" borderColor="Transparent" fontBold="True" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleMonthHeader">
          <states>
            <state name="Normal" foreColor="60, 60, 60">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleOwner">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" />
          </states>
        </style>
        <style role="ScheduleOwnerHeader">
          <states>
            <state name="Normal" foreColor="75, 75, 75" borderColor="Transparent" imageBackgroundStretchMargins="3, 3, 5, 3">
              <resources>
                <name>background</name>
              </resources>
            </state>
            <state name="HotTracked" foreColor="30, 30, 30" />
            <state name="Active" foreColor="232, 0, 0" />
          </states>
        </style>
        <style role="ScheduleTrailingDay">
          <states>
            <state name="Selected" backColor="210, 210, 210" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScheduleWeekHeader">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="Black" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScrollBarArrowDown">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABFUlEQVQ4T82UXYqDMBRGu1oXoUtQEF2QIkZRDCONGJSo6Eq+3kQdKoVq56FMIK+H+3O+ewO9KIqwLAvmecY0jlBKoe97yFaiEQJ1XaPiFYqyQJ7lYIwhSRLEcWz+7RUyQQ0bREqIptkgHEVRIs9zpN+BTNSOrqTr0VIlzVMlZVkiu1LJqCF6Jl2HVs/kF1JhhzCWvp/JP4KME8IwhGVZL991XbMdlp61QxClBgRBcIB4nkcrJk8+gQhxh+M4BmTbNm0l+xzSkbF1/QPf981WKq5lWytJ0xNjx037znjSHo3dPfkSRA9WZ4dkO2SHZNuycy7bUztSay/WAPKKUnw5gKT9QCs22SHtRbOeAr6fgivZmf4AeQAc+tKBjwoeVwAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="{None}" foreColor="White">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABFUlEQVQ4T82UTWuEMBRF5///KEWSEUNkhARtbIzo1inS6UKXty9+lJGB6nQxNJDt4X2c+06gFwQB2rZF0zSonYO1FmVZosgLaKWQZRlkKpGIBPE5BuccURQhDMPpnx4hNWy1QIoCSusFkiJJBOI4BnsNpKZ2fCWmRE6V6LtKhBA4H6nEeYifiTHI/Ux+IBIrhHP2+0z+EcTVuN2+/NIeXtd103Y422uHINZWBPrcQK4fV1oxefIMxNp3jOM4gYZhwCW7PA8xZKwxb+j7HoqslamXba6EsR1j3aK9mTzJt8aunrwI4gfrs0OybbJDsi3Z2Zftrp3Ca6/mAKaSUnw4gKR9RSueskPaKz2fgnQ9BUeyU/8B8g2J5+uNns/oygAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="Pressed" colorCategory="Primary Color" foreColor="White">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABHUlEQVQ4T82UwWqEMBRF/ZuZf5mWoe3/asWMKAkVIoZITNBtC4Vu2uXtS9QytlCdLoYGsj3cvHduItCJ4xjDMKDvezhrYYxB27ZQjUItJaqqAhccRVkgP+VgjCFNUyRJEm70E+JgugmiFGRdTxCBoiiR5zmy60AcPccn0S0aSlKfJSnLEqctSayH+JlojcbP5AvCMUMYy36fyT+CWIe3+wcgosV9u8+HQ9gOy9aeQxBjOgLdLSAvtze0YvLkEoghuT72+wB63+3w9JhcDtFkrCZDX49HSIrPhZdtTJJlK8baSXsdPGmWxs6eXAniB+u7Q7ItukOyTd1Zl+3sOcprL8cCCk4t3lxA0r6jFYfukPayHr8CMX8FW7rj/gD5BKWUz7VeSDzuAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScrollBarArrowHorizontal">
          <states>
            <state name="Normal" backColor="White" foreColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="HotTracked" colorCategory="Primary Color" foreColor="White" />
            <state name="Pressed" backColor="White" foreColor="141, 0, 0" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScrollBarArrowLeft">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGElEQVQ4T63ObYqDMBAG4Lmpl2jP0LLFHqkiRokolY0oih/oSd6dSay1Qn+5woPJzDtDKAgCHEVHF8g8hWGIo0gphWhDqQiriM+LKOLcQvrbGUriBEnixDuv+r6/r5NONbROrTT9pLX0nMvlAs19kS55O8soyzNkeb4h9zcVK1yvV3ie95HJsww55wQVRYFv5AWn08kuEN9yVBoDU5ZWufNzu60LZMkrZ7NGZmTWgOqqRl07leD7S/F84nw+r4uquuKMWPJLltq2xarhc9O8tQ2M+YXv+3ZRw33Rct3+F9R1Hbp+Q+6rns/O/X7f1F2m57qgcRgwDqMzDhi2uDZ84D7nXY3nOCtomiYcRfM84yh6PB44ivAP3x+qgdFbYZonXgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="{None}" foreColor="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGUlEQVQ4T6XSwYqDQAwG4Lz/Q1VEKyNKBUWra0f0ahdZ96DHf5MZtVboZR34cCb5k5PkOA7OorMLZJ5c18VZ5Ps+vB3f97Dx+L7wPM4tpL+foeAaIAis68FaP/aPdVKhglKhEYbvlJKe1fc9FPdFuOTNLKMojhDF8Y68X27JDc/vJ+S8chHiiHFOUJIk+CRNU0zTZBbI+ZSjjINplhnZwTAM2wK5rDmTTWVGZlNQkRcoCisX/F6V9zvmed4W5UXOGbHklyxVVYVNyfeyfKlK1PUXxvHHLCq5Lyqum++C6rpG/diR9+bBd2scf3d1m3lwXVCjNRrdWI2G3uOafsN9ztsaz3FWUNu2OIu6rsNZdLlccBa9/Qj/fPwBQ0rri7sUph8AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
            <state name="Pressed" colorCategory="{None}" foreColor="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGUlEQVQ4T6XSwYqDQAwG4Lz/Q1VEKyNKBUWra0f0ahdZ96DHf5MZtVboZR34cCb5k5PkOA7OorMLZJ5c18VZ5Ps+vB3f97Dx+L7wPM4tpL+foeAaIAis68FaP/aPdVKhglKhEYbvlJKe1fc9FPdFuOTNLKMojhDF8Y68X27JDc/vJ+S8chHiiHFOUJIk+CRNU0zTZBbI+ZSjjINplhnZwTAM2wK5rDmTTWVGZlNQkRcoCisX/F6V9zvmed4W5UXOGbHklyxVVYVNyfeyfKlK1PUXxvHHLCq5Lyqum++C6rpG/diR9+bBd2scf3d1m3lwXVCjNRrdWI2G3uOafsN9ztsaz3FWUNu2OIu6rsNZdLlccBa9/Qj/fPwBQ0rri7sUph8AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScrollBarArrowRight">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="DimGray">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGElEQVQ4T63PbYqEMAwG4NzJizh7DWcRZ++nOH6gKCsoSkUrepJsYqvbcZlfXeHBNnkTFKIoQltgu4DnIY5jtAVpmmJiSNMETwmdtSShnMZ9cwbyLMc8V7KLo37tX+tQlAUWRbkry1ee51Gd+xr1C87o/D5LoKorrOrawHfFcRy8f94xfsZ/MnVVYU0ZBk3T4Du8hLmui1mWvc1B17bYdt2uuziW8Nv3/TO3Z1ue4dkWYegHHAalZ3Q/HEs+brf9s/uh13ReZ2EcRzwJOgtx4iVBENBvfKOgnKA+G0eh3hpM04TTbOC79nh80Xk2/PY4M1OPwSIlLnJRFonSRDX5gvqUVzWaoyyDdV3RFmzbhrYgDEO0BfgPzw+o9cod+MJxugAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" foreColor="White" />
            <state name="Pressed" colorCategory="{None}" foreColor="White">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGElEQVQ4T63PbYqEMAwG4NzJizh7DWcRZ++nOH6gKCsoSkUrepJsYqvbcZlfXeHBNnkTFKIoQltgu4DnIY5jtAVpmmJiSNMETwmdtSShnMZ9cwbyLMc8V7KLo37tX+tQlAUWRbkry1ee51Gd+xr1C87o/D5LoKorrOrawHfFcRy8f94xfsZ/MnVVYU0ZBk3T4Du8hLmui1mWvc1B17bYdt2uuziW8Nv3/TO3Z1ue4dkWYegHHAalZ3Q/HEs+brf9s/uh13ReZ2EcRzwJOgtx4iVBENBvfKOgnKA+G0eh3hpM04TTbOC79nh80Xk2/PY4M1OPwSIlLnJRFonSRDX5gvqUVzWaoyyDdV3RFmzbhrYgDEO0BfgPzw+o9cod+MJxugAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScrollBarArrowUp">
          <states>
            <state name="Normal" colorCategory="{None}" backColor="Transparent" foreColor="Transparent" backGradientStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABFklEQVQ4T82UW4qDQBBFs1M3oWtQJuiSFLGVbpSYKIrSKrqSO1U+hkhgNPMRRmj8O1TXPbcvoM/3fUzThHEcMfQ9tNZo2xZ1VaMsCuR5jjRLIZVEEicQQiAMQwRBMJ/LK2SA7lZIXaMoyxWSQUqFJEkQfQYy0HV4kqZFRZOUT5MopRCfmaRnCO+kaVDxTn4gKTaIENHvO/lHkJ7S0R1F3CC/3fB1vVIqcomY/pyOiI6us0Iejzssy4JhGDBNEyIW70Nc150B23Ec5z2I53k7wAaybXuRLTowtl+1b2ZPqr2xmycfgnA63B2Sbdcdkm3tzrFsT9epWftiKWCWcsRnC0jad+wJ74S0L8rlKci2p+BMd4Y/QL4B9EzRWHUq1HMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="{None}" foreColor="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAqwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABFElEQVQ4T82UwWqEMBCG9/0fShGzElFWiBhio6JXt0jtQY9/Z6KWlUJ1e1gayCGXj5n5v8kFdDzPQ9d1aNsWTV3DWouyLKELjVwpZFmGJE0gY4noGkEIgSAI4Pu+u5efkAa2WiFaQ+X5CkkhZYwoihC+BtJQO1yJKVFQJflDJXEc43qmkpohPBNjUPBMviEJNogQ4e8z+UeQmtKxFUVsXEvDMEBRzC5iSRHTTER41M4KsfYN8zyzAZimCbfs9jxkHD8cYDv39/tzkHH83AG2R9/3i2zhgbH1qr1xnhR7YzdPXgThdHh3SLbd7pBs6+4cy/bQjmbt1bKAacIRn11A0r5iT3gmpL3Kl68g3b6CM7vT/AHyBf42647QlV8eAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
            </state>
            <state name="Pressed" colorCategory="Primary Color" backColor="Transparent" foreColor="Transparent" backGradientStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAswEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAABEIBgAAADttR/oAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABHElEQVQ4T82U0WqDMBSGfZv2XbpR2r2vYk1DnDIhYjDEiN5uMOjNdvkvR+OoDKbdRZmQC28+Ts7//QngvjAM0fc9uq5Day2MMdBaQ1UKpZQoigJZnkGkAvzMwRhDHMeIomg4wU9IC9N4iFKQZekhOYRIwTlHch9I665Dk9QalZukvJokTVOc10xiCUI7qWtUtJNvSIYJwljy+07+EcS6dEzjIq6hhcD7fg95Oo0Ru39KhyVL1/EQkz3jc7sFggAfmw1eovB2yOV4GADTeXt8uA1yOT7NABPodbcbZUsWjLVe+3rwpJobO3lyJwilQ91xss2642Tz3VmW7eo6irSXYwHzjCJeW0CnfUOe0E6c9rIcn4J8egrWdKf9A+QLtJnPrvPGR4sAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScrollBarArrowVertical">
          <states>
            <state name="Normal" colorCategory="{None}" foreColor="180, 180, 180">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAlgEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAA/0lEQVQ4T6WTyY2DQBBFOwNPJuNguI8zcC4QiH2AGxFwQYBYJRax3xxCDa+lQWPsg22QWqX69X7RNNVKbR7HcU6e513DMLxFUSREcvQtu+aWZR19368xxHEsaZpKlmU6kqNTh7trghAEwQ0IQ1EUUlWV1HWtIzk6dbi1gWEYXwhJkkie5xpu21a6rpO+73UkR6cOB49Pua57piMF3gQ8DINM07QucnTqcPD41PIdPt9VlqUGxnGUeZ4fFjp1OHh8ioOgW9M0epvPjH8adTh4fPvMu7a968CWIz98+KsOelhM0/x+Z0jg76YM4ZXxfDD+72Lb9s9yES6bi3FB316MX9bvaCfxXRXxAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
            </state>
            <state name="HotTracked" foreColor="White">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarHorizontal">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="11, 0, 12, 0" />
          </states>
        </style>
        <style role="ScrollBarIntersection">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScrollBarThumbHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarThumbHorizontal_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>scrollBarThumbHorizontal_HotTracked</name>
                <name>RedGripHor</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>scrollBarThumbHorizontal_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarThumbVertical">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 15, 0, 15">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAswAAAAKJUE5HDQoaCgAAAA1JSERSAAAABgAAAAUIBgAAAGZYneYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAHElEQVQYV2MwNjb+D8JAwIDMZgAJYMMoqijTAQC5skjr9sKxAgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
              <resources>
                <name>scrollBarThumbVertical_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>scrollBarThumbVertical_HotTracked</name>
                <name>RedGripVertial</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>scrollBarThumbVertical_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarTrackHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarTrackHorizontal_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarTrackSectionBottom">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 0, 0, 8" />
          </states>
        </style>
        <style role="ScrollBarTrackSectionTop">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 7, 0, 0" />
          </states>
        </style>
        <style role="ScrollBarTrackVertical">
          <states>
            <state name="Normal" colorCategory="{None}">
              <imageBackground>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</imageBackground>
            </state>
          </states>
        </style>
        <style role="ScrollBarVertical">
          <states>
            <state name="Normal" backColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 12, 0, 12" />
          </states>
        </style>
        <style role="SpinButtonDownNextItem">
          <states>
            <state name="Normal" foreColor="Red" />
          </states>
        </style>
        <style role="SpinButtonUp">
          <states>
            <state name="Normal" foreColor="White" />
          </states>
        </style>
        <style role="SpinButtonUpMinValue">
          <states>
            <state name="Normal" foreColor="White" />
          </states>
        </style>
        <style role="SpinButtonUpPrevItem">
          <states>
            <state name="Normal" foreColor="Red" />
          </states>
        </style>
        <style role="StateEditorButton">
          <states>
            <state name="HotTracked" backColor="250, 250, 250" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA1AAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEwAAACkIBgAAANexEgcAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAPUlEQVRIS2P4T0XAQEWz/o8aRnpojobZaJjhCIHRpDGaNEaTBulpYDTMRsOMtBAYLWlJCy+Q6tEwG05hBgCuoSCJ1c2N1wAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="Pressed">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMgAAADIIBgAAAB4/iLEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlElEQVRoQ+3XMQ6AMAxD0d7/0kVcgMWyWqI3MNoo/okFa++9JjwjhnhBGOS2dUQEkVJLWi2rZbW+v0DciBtxI27kX/8pWktraS2tpbWONOGRlzYazyCNVBNPRJL0GlpEGqkmnogk6TW0iDRSTTwRSdJraBFppJp4IpKk19Ai0kg18UQkSa+hRaSRauKJSJJeQzuGyAMM7jBonEmhzgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="StatusBarPanel">
          <states>
            <state name="Normal">
              <resources>
                <name>BlackForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="StatusBarPanelStateButton">
          <states>
            <state name="Normal" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAGgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHwAAABQIBgAAAHVp5voAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAg0lEQVRIS8XWwQnEIABE0fRfla2IYlDEoCiKCLNkD1PC5PDP7/ovYwy+6nrhc4681/3je295xNdaUEd8zgl1xMcYUEe89w51xFtrUEe81gp1xJ/ngTripRSoI55zhjriKSWoIx5jhDri931DHfEQAtQR995DHXHnHNQRt9ZCHfGvNuoHjXj4e7Kznq0AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
              <resources>
                <name>BlackForeground</name>
                <name>background</name>
              </resources>
            </state>
            <state name="Pressed">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAARgAAAAJHSUY4OWEBAAEAgQAA////AAAAAAAAAAAAIf8LTkVUU0NBUEUyLjADAQEAACH5BAEAAAAALAAAAAABAAEAAAgEAAEEBAA7CwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
              <resources>
                <name>background</name>
                <name>Blank</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="StatusBarProgressBar">
          <states>
            <state name="Normal">
              <resources>
                <name>BlackForeground</name>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlClientArea">
          <states>
            <state name="Normal" borderColor="107, 168, 18" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 16, 0, 0" />
          </states>
        </style>
        <style role="TabControlClientAreaHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>BorderHighlight</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlClientAreaVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>BorderHighlight</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabItemAreaHorizontalBottom">
          <states>
            <state name="Normal">
              <resources>
                <name>TabBottomBG</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabItemAreaHorizontalTop">
          <states>
            <state name="Normal">
              <resources>
                <name>TabTopBG</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabItemAreaVerticalLeft">
          <states>
            <state name="Normal">
              <resources>
                <name>TabLeftBG</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabItemAreaVerticalRight">
          <states>
            <state name="Normal">
              <resources>
                <name>TabRightBG</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabItemHorizontalBottom">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabControlTabItemHorizontalTop" buttonStyle="FlatBorderless">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabControlTabItemVerticalRight">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabControlTabsAreaHorizontalTop">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabsAreaVerticalRight">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabItemAreaHorizontalBottom">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabItemHorizontalBottom" buttonStyle="FlatBorderless">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="9, 0, 12, 11">
              <cursor>Hand</cursor>
            </state>
            <state name="Selected">
              <resources>
                <name>TabItemHorizontalBottom_HotTracked</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>tabItemHorizontalBottomAppletini_Selected</name>
              </resources>
            </state>
            <state name="HotTrackSelected" foreColor="Black">
              <resources>
                <name>TabItemHorizontalBottom_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemHorizontalTop">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <cursor>Hand</cursor>
            </state>
            <state name="Selected">
              <resources>
                <name>TabItemHorizontalTop_HotTracked</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>TabItemHorizontalTop_Selected</name>
              </resources>
            </state>
            <state name="HotTrackSelected">
              <resources>
                <name>TabItemHorizontalTop_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemVerticalLeft">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <cursor>Hand</cursor>
            </state>
            <state name="Selected" foreColor="Black">
              <resources>
                <name>TabItemVerticalLeft_HotTracked</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>tabItemVerticalLeft_Selected</name>
              </resources>
            </state>
            <state name="HotTrackSelected" foreColor="Black">
              <resources>
                <name>TabItemVerticalLeft_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemVerticalRight">
          <states>
            <state name="Normal" imageBackgroundStretchMargins="0, 9, 16, 9">
              <cursor>Hand</cursor>
            </state>
            <state name="Selected" imageBackgroundStretchMargins="0, 8, 10, 12">
              <resources>
                <name>TabItemVerticalRight_HotTracked</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>tabtemVerticalRight_Selected</name>
              </resources>
            </state>
            <state name="HotTrackSelected">
              <resources>
                <name>TabItemVerticalRight_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TaskPaneToolbarMenu">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="TileCloseButton">
          <states>
            <state name="HotTracked">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAGQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAA0IBgAAAE95hRoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAgklEQVQ4T7WT0Q2AMAhEGcERHdk9HAJ7jSXXE00btQkfEHgcpTV3t8TWEtuK8YGP+CVfA0tSLKwKR17UKkS7K6D5yEshkDpzYjRWEip2M28Gqvpnp1DDkE4FFzJQpNb6W8iDAub8A+k2MzBOeiexncGLTbeD+V6/E0A+ebFtW1N/5wCtJONXnfQ1bAAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
            </state>
          </states>
        </style>
        <style role="TileHeader">
          <states>
            <state name="Normal">
              <resources>
                <name>TabItemHorizontalTop_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TileStateChangeButtonLarge">
          <states>
            <state name="Normal">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA4AAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAA0IBgAAAE95hRoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAASUlEQVQ4T2P4//8/A6WYYgNADqC5IUBLcAIUy/G5hGqGYLMEZDhBlxByAcWGwCwgyiVEeQPmLVIUY3iDkCG4wgVrbNI8sRFtAQBnwMBcfuMWNQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAwAAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAABQIBgAAAI2JHQ0AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAKUlEQVQ4T2P4//8/AzUxVQ0DOWzUQMojaDQMR8OQjHw+mmxGkw0ZyQYAROOrjRU8tTgAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAbQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAA0IBgAAAE95hRoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAA1klEQVQ4T42SwQ6CQAxEhz/gE/1hE2JivHjQC4nx4kVFDa4zZEtK2QhN5rDdmUcLIAFpps0mpaZJk9JZ/YIfPZuj6noenqKG+54+n8ObENM3Pj0C8lk+n0NHiPTRqK5a9tqqmkvrsOS3LO5sSn2YYoCURLBKfsviRqMUS1OUyvctiysBktW4RlwnezzEsrCRJ5A/q8gfvTizKb3yO1mzhiDyWxZHAqRL/jprIfJbFgcCTB3pS59WU8jnc9gRYtrzT3wu/HC6l8/nsCUk6sRRHwGms/ol/w/p+WbN9IVzmgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
            </state>
          </states>
        </style>
        <style role="TileStateChangeButtonNormal">
          <states>
            <state name="Normal">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA2AAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAA0IBgAAAE95hRoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAQUlEQVQ4T2P4//8/A6WYYgNADhj8hgBd+f8fFgwSx3A9Lu+AFGMDIIOJNgSrYqjL6GsIVcKEpKgnSTGulD14DAEAT0etYAVWD74AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAwAAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAABQIBgAAAI2JHQ0AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAKUlEQVQ4T2P4//8/AzUxVQ0DOWzUQMojaDQMR8OQjHw+mmxGkw0ZyQYAROOrjRU8tTgAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked">
              <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAEQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAA0IBgAAAE95hRoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAeklEQVQ4T72T0Q3AIAhEcYOO2JE7hWtQjkRCDn5MTUn4EOF5goqqSuO3xR7zbFgjXvI5cDXFxHI48qKWIXw6A9YaeS0EUncsrpaVhIoponOM6hZPFmoyJPYd0rmByby+h9Rkr4W6XyBHenJkOujP53cCyJEXu6a19XdeRmHpLkimubMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
            </state>
          </states>
        </style>
        <style role="TimelineViewColumnHeaderBase">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9QAAAAKJUE5HDQoaCgAAAA1JSERSAAAAGgAAABIIBgAAAEUZzqMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAXklEQVRIS73DUQoAEBQEwL3/LUXkSQiRn3WLnRq896iIey8Vcc6hIvbeVMRai4qYc1IRYwwqovdORbTWqIhaKxVRSqEizIyKyDlTESklKiLGSEWEEKgI7z0V4Zyj4geNy+mte7+E2wAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="TimelineViewColumnHeaderDateNavigationButton">
          <states>
            <state name="Normal" foreColor="244, 0, 0" />
            <state name="HotTracked" foreColor="White">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TimelineViewColumnHeaderPrimaryInterval">
          <states>
            <state name="HotTracked" foreColor="254, 0, 0" />
          </states>
        </style>
        <style role="TimelineViewTimeSlotNonWorkingHour">
          <states>
            <state name="Normal" backColor="225, 225, 225" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="254, 0, 0" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TimelineViewTimeSlotWorkingHour">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="254, 0, 0" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarBase">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarCloseButton">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="White" fontBold="True" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="Black" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarDockAreaFloating">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" />
          </states>
        </style>
        <style role="ToolbarDockAreaTop">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarEditAreaComboBox">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarEditAreaFontList">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="ToolbarEditAreaMaskedEdit">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarEditAreaProgressBar">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarEditAreaTextBox">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarFloatingCaption">
          <states>
            <state name="Normal">
              <resources>
                <name>TopRed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarGrabHandle">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemButton">
          <states>
            <state name="HotTracked" foreColor="White" borderColor="Transparent">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemComboBox">
          <states>
            <state name="HotTracked">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemFontList">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="HotTracked">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemMaskedEdit">
          <states>
            <state name="HotTracked" foreColor="White">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupColorPicker">
          <states>
            <state name="HotTracked">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupControlContainer">
          <states>
            <state name="HotTracked" borderColor="Transparent">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupMenu">
          <states>
            <state name="HotTracked">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemQuickCustomize">
          <states>
            <state name="Normal" colorCategory="Primary Color" foreColor="232, 0, 0">
              <resources>
                <name>Blank</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="Black" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="Pressed" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="4, 4, 4, 4">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAeQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAA4klEQVQ4T7WVsQqDMBRF/cLaz3RXNwUXQZQUQQRBEMFRRKcqtOU219YUutU+hzO+wyMkJxYA6wgsz/PIWXPRPDQ3zX0nSs/ZdG7Sa1VVGIYB0zTtou97lGUJLR0pt8IwhFIKbduKkKYpgiAAN0ae5yiKQgS66FzFWZaJYsRJkkASI47jGJIcv7HjOJDEbOy6LiQxYt5lSY4/Y6nHsXnMxnVdQ5JV7Pv+2oiu60Romub1pKMoWqu0t2rfc2wFnWzFSTNQPo4j5nnGsiw/w1me8bvj9hZ6yhlphv4fPqE/4lui8wngCrDBdnoBNQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
            <state name="Active" borderColor="Transparent" />
          </states>
        </style>
        <style role="ToolbarItemStateButton">
          <states>
            <state name="HotTracked">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemTaskPaneLabel">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="Black" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneMenu">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneMenuDropDownOnly">
          <states>
            <state name="Normal" colorCategory="Primary Color" foreColor="Transparent" imageBackgroundStyle="Centered">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAPwEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAqElEQVQ4T6WTgQ2EIAxF/wa6iWykGzjauQkjOMKNwPUjjRRL7vRIGgP89621RUoJJoAlAZvEW0Ju85P7pdWeIBBEsBeAkBe8D2pywAeob+qBek5dNiA43gBrg5Hw+iXVXiYr4Whgyae7bB0i4auzRzs6H6awXn7lc6Vt2rWQBh2Q3N8FGx7+qkGbZLphwCaZygeV3ubBb+2ZQQvrgACzmLyaweB+bgfjA2Dky/p4cEAcAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="Primary Color" backColor="Transparent" foreColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAPQEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAApklEQVQ4T6WT4RWDIAyEbwPdBDbSDRitbuIIjtARaC40T0yhrfojzwfcdzkxIueMQwFzBhapp5Sc6pPr2Wt3EIgi2N4AoVbxPJpJgQtonXqg7VOnBgTHE2BtMBJOP6L2kiTCaw1Dw7TLNVmp+nBuwU1dL3Jt0NX42P4VvtyHxr51YcPFTzXYkIQTBhySUIbEZpsb/42ngkd4N5nE5FElYSeuJ/9jvABlGZwq9udgYQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="Pressed">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemTaskPaneNavigation">
          <states>
            <state name="Normal" foreColor="White" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneNavigationBack">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="White" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="45, 45, 45" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneNavigationForward">
          <states>
            <state name="Normal" foreColor="White">
              <resources>
                <name>button_Pressed</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="45, 45, 45" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTextBox">
          <states>
            <state name="HotTracked" borderColor="Red">
              <resources>
                <name>ExplorerBarGroupHeader_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolTipBalloon">
          <states>
            <state name="Normal">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TrackBarButton">
          <states>
            <state name="Normal" foreColor="DimGray" />
          </states>
        </style>
        <style role="TrackBarMidpointTickmarks">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TrackBarThumbHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>Default_TrackBarThumbHorizontal_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>Default_TrackBarThumbHorizontal_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>Default_TrackBarThumbHorizontal_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TrackBarThumbVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>Default_TrackBarThumbVertical_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>Default_TrackBarThumbVertical_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>Default_TrackBarThumbVertical_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TrackBarTickmarks">
          <states>
            <state name="Normal" colorCategory="{None}" backColor="Gray" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TrackBarTrack">
          <states>
            <state name="Normal" colorCategory="{None}" backColor="LightGray" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TreeCell">
          <states>
            <state name="Normal" borderColor="210, 210, 210" />
          </states>
        </style>
        <style role="TreeColumnHeader">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TreeControlArea">
          <states>
            <state name="Normal" borderColor="Gainsboro" />
          </states>
        </style>
        <style role="TreeNode">
          <states>
            <state name="Selected" backColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>RedForeground</name>
              </resources>
            </state>
            <state name="HotTracked" foreColor="241, 0, 0" />
          </states>
        </style>
        <style role="UltraButton">
          <states>
            <state name="Normal" borderColor="Transparent" borderColor3DBase="Transparent" borderColor2="Transparent">
              <resources>
                <name>BlackForeground</name>
                <name>buttonBorder</name>
              </resources>
            </state>
            <state name="HotTracked" backColor="Transparent" foreColor="Red" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraButtonBase">
          <states>
            <state name="Normal" borderColor="Transparent" borderColor2="Transparent" />
          </states>
        </style>
        <style role="UltraButtonDefault">
          <states>
            <state name="Normal" borderColor="Transparent" borderColor3DBase="Transparent" borderColor2="Transparent" />
            <state name="Pressed" backColor="Transparent" foreColor="254, 0, 0" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" borderColor2="Transparent">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMgAAADIIBgAAAB4/iLEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlElEQVRoQ+3XMQ6AMAxD0d7/0kVcgMWyWqI3MNoo/okFa++9JjwjhnhBGOS2dUQEkVJLWi2rZbW+v0DciBtxI27kX/8pWktraS2tpbWONOGRlzYazyCNVBNPRJL0GlpEGqkmnogk6TW0iDRSTTwRSdJraBFppJp4IpKk19Ai0kg18UQkSa+hRaSRauKJSJJeQzuGyAMM7jBonEmhzgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="UltraCalculator">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>background</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraCalculatorButton">
          <states>
            <state name="Normal" colorCategory="{None}" backColor="Transparent" foreColor="DimGray" imageBackgroundStyle="Stretched" fontBold="True" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAALAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIQAAABYIBgAAAE6b9XoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlUlEQVRIS8XWMQrEIBSE4dz/VF5FlARFlEhEEWGWbLGwTD8WX/3+180B4NjtG2CMwS7v/V/EWgtq7+N/EXNOqFHEGANqFNF7hxpFtNagRhHP80CNImqtUKOI+76hRhGlFKhRRM4ZahSRUoIaRcQYoUYRIQSoUcR1XVCjiPM8oUYR3nuoUYRzDmoUYa2FGkVsn3e7h+4HnxE1W9XvhCMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="HotTracked" colorCategory="Primary Color" foreColor="White" imageBackgroundStyle="Stretched">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAJwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIQAAABYIBgAAAE6b9XoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkElEQVRIS8XWwQbDQBhF4bz/U81zRKiKiFKhqkpFJjdZlDj7M4vD7Ob7d7ertXatOwGllNqq4/8/os/T7jj8ghiCsAPiFoQdEPcg7IAYg7ADYgrCDog5CDsgHkHYAfEMwg6IJQg7IF5B2AHxDsIOiE8QdkB8g7AD4heEHRBrEHZAbEHYAXHuGzkgms+71kN3B7UKZpAk9QY6AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
            <state name="Pressed" colorCategory="Primary Color" foreColor="DimGray" imageBackgroundStyle="Stretched">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAJwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIQAAABYIBgAAAE6b9XoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkElEQVRIS8XWwQbDQBhF4bz/U81zRKiKiFKhqkpFJjdZlDj7M4vD7Ob7d7ertXatOwGllNqq4/8/os/T7jj8ghiCsAPiFoQdEPcg7IAYg7ADYgrCDog5CDsgHkHYAfEMwg6IJQg7IF5B2AHxDsIOiE8QdkB8g7AD4heEHRBrEHZAbEHYAXHuGzkgms+71kN3B7UKZpAk9QY6AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="UltraCalculatorButtonAction">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonImmediateAction">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonOperator">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonPendingCalculations">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraDropDownButtonMainButton">
          <states>
            <state name="Normal" foreColor="60, 60, 60" borderColor="Transparent" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="12, 8, 11, 8">
              <resources>
                <name>buttonBorder</name>
              </resources>
            </state>
            <state name="Pressed" backColor="Transparent" foreColor="Black" backGradientStyle="None" backHatchStyle="None">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMgAAADIIBgAAAB4/iLEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlElEQVRoQ+3XMQ6AMAxD0d7/0kVcgMWyWqI3MNoo/okFa++9JjwjhnhBGOS2dUQEkVJLWi2rZbW+v0DciBtxI27kX/8pWktraS2tpbWONOGRlzYazyCNVBNPRJL0GlpEGqkmnogk6TW0iDRSTTwRSdJraBFppJp4IpKk19Ai0kg18UQkSa+hRaSRauKJSJJeQzuGyAMM7jBonEmhzgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="UltraDropDownButtonSplitButton">
          <states>
            <state name="Normal" foreColor="232, 0, 0">
              <resources>
                <name>buttonBorder</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraGroupBox">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraGroupBoxContentArea">
          <states>
            <state name="Normal">
              <resources>
                <name>blueWhite</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraPictureBox" borderStyle="None">
          <states>
            <state name="Normal">
              <resources>
                <name>blueWhite</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraSplitterButtonDockedBottom">
          <states>
            <state name="Normal">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraSplitterButtonDockedLeft">
          <states>
            <state name="Normal" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_Normal</name>
              </resources>
            </state>
            <state name="HotTracked" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraSplitterButtonDockedRight">
          <states>
            <state name="Normal">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedRight_Vertical_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraSplitterButtonDockedTop">
          <states>
            <state name="Normal" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_Normal</name>
              </resources>
            </state>
            <state name="HotTracked" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed" borderColor="Silver">
              <resources>
                <name>Default_UltraSplitterButtonDockedBottom_Horizontal_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraStatusBar">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraTabControl">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraTabStripControl">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraTextEditor">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>BlackForeground</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraTile">
          <states>
            <state name="Normal" backColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="1, 1, 1, 1">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAvQAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFQAAAA8IBgAAAAtahGsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsPAAALDwGS+QOlAAAAJklEQVQ4T2Po7Jn6HwgYqIVB5jGMGjoapqNJikq5ajRHQQoUamMAf3+daZBBO7EAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="UnpinnedTabAreaBottom">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaLeft">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaRight">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaTop">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 4, 0, 0">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxAAAAAKJUE5HDQoaCgAAAA1JSERSAAAAEQAAAB0IBgAAAEyvh4EAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAALUlEQVRIS2P4z8Dwn1IMNIFyMGoIZhiOhslomBCTs0bTyWg6GU0nxITAsE8nAHGqitjYylA0AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
            </state>
          </states>
        </style>
        <style role="UnpinnedTabItemHorizontalBottom">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemHorizontalTop">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemVerticalRight">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>tabtemVerticalRight_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="WeekViewControlArea">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
      </styles>
      <sharedObjects>
        <sharedObject name="ScrollBar">
          <properties>
            <property name="MinimumThumbExtent">20</property>
            <property name="MinimumThumbHeight" colorCategory="{Default}">25</property>
            <property name="MinimumThumbWidth" colorCategory="{Default}">25</property>
          </properties>
        </sharedObject>
        <sharedObject name="TrackBarEditor">
          <properties>
            <property name="TrackThickness" colorCategory="{Default}">2</property>
          </properties>
        </sharedObject>
      </sharedObjects>
    </styleSet>
    <styleSet name="Ribbon">
      <styles>
        <style role="Base">
          <states>
            <state name="Normal" themedElementAlpha="Transparent" />
          </states>
        </style>
      </styles>
    </styleSet>
  </styleSets>
  <resources>
    <resource name="background" colorCategory="{None}" backColor="White" foreColor="15, 15, 15" borderColor="Silver" backColor2="Gainsboro" backGradientStyle="Vertical" />
    <resource name="BackgroundRed" colorCategory="Primary Color" backColor="232, 0, 0" foreColor="White" fontBold="True" backGradientStyle="None" backHatchStyle="None" />
    <resource name="BlackForeground" colorCategory="{None}" foreColor="DimGray" />
    <resource name="Blank" colorCategory="{None}" backColor="Transparent" foreColor="White" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" imageBackgroundStretchMargins="4, 4, 5, 4" />
    <resource name="blueWhite" colorCategory="Secondary Color" backColor="White" foreColor="White" backColor2="226, 241, 248" backGradientStyle="Vertical" />
    <resource name="BorderHighlight" colorCategory="Primary Color" backColor="White" borderColor="241, 0, 0" backGradientStyle="None" backHatchStyle="None" />
    <resource name="BottonBorderRed" colorCategory="Primary Color" foreColor="White" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="3, 3, 3, 3">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAJwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIQAAABYIBgAAAE6b9XoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkElEQVRIS8XWwQbDQBhF4bz/U81zRKiKiFKhqkpFJjdZlDj7M4vD7Ob7d7ertXatOwGllNqq4/8/os/T7jj8ghiCsAPiFoQdEPcg7IAYg7ADYgrCDog5CDsgHkHYAfEMwg6IJQg7IF5B2AHxDsIOiE8QdkB8g7AD4heEHRBrEHZAbEHYAXHuGzkgms+71kN3B7UKZpAk9QY6AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="button_Pressed" colorCategory="Primary Color" backColor="Transparent" foreColor="White" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="6, 5, 6, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAKQEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAAA4IBgAAAPCKRu8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAkklEQVQ4T6WT0Q2AIAxEbwPdRDeCDRxNN3EER3CE2gMbhUhU+GgItO8ocEBEkATgBVg0dg3NhpFzn9deIDBqwXYChJ6C+dFEIhxB26kE2jrrggDB/gd4F+gJTy+tljqZCK+V8Er47YzFfDPc1HbThXWVT9WZSYYfAjTJEE1i3ubCN3sGMIUvEacic/YxOHf5xzgAc6KsGgslADAAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="buttonBorder" colorCategory="{None}" foreColor="Black" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="3, 3, 3, 3">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAALAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIQAAABYIBgAAAE6b9XoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlUlEQVRIS8XWMQrEIBSE4dz/VF5FlARFlEhEEWGWbLGwTD8WX/3+180B4NjtG2CMwS7v/V/EWgtq7+N/EXNOqFHEGANqFNF7hxpFtNagRhHP80CNImqtUKOI+76hRhGlFKhRRM4ZahSRUoIaRcQYoUYRIQSoUcR1XVCjiPM8oUYR3nuoUYRzDmoUYa2FGkVsn3e7h+4HnxE1W9XvhCMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Circle2" colorCategory="Primary Color" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAALAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAEAAAAA4IBgAAACYvnIoAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAlUlEQVQ4T62T4RGAIAiF3wa2SW2UGzhabeIIjdAIBhqnWZ6Z/eA8kfcJCnDO4WaAdsBKtpNRhF95r/PYqxiYKGg7RSx8Mj6fBBQBQSw3lsTi5zgPCQBgaBCnkEEAppJ2KSMjAPsRYAVQq7l4/hugu4TuR1Qfv1GljTQ2QLiRxthIMg/sfNfKXnwHRNBMoCUbJt7P+TAdTEDV8Cjc6uMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbHorizontal_HotTracked" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtwAAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAIElEQVQ4T2P4//8/A7GYaIUgA0cVIwfraGiMhgaubAYAL92Riw/41HQAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA6wAAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAVElEQVQ4T2PIzMz8TyxmACkkBoDUjSqGhdRoaCCnGXhonDlzBm9aAsmDFQNVgRMTLg0whSB1YMW4NCArRFGMrgFdIYZiZA3QTAG3GatimAaY85BpAFX+9QymrQftAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbHorizontal_Normal" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtwAAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAIElEQVQ4T2P4//8/A7GYaIUgA0cVIwfraGiMhgaubAYAL92Riw/41HQAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAMwEAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAnElEQVQ4T43SUQqEIBSF4bbrXltFIYYYSiiRCGfQwYszNZx5+EH0u/ripJTCv00VllJo1TWcc6YJvq4LLMHneYIlOKUEluAYI1iCj+MAS3AIASzB3nuwBO/7DpZg5xxYgq21YAnetg0swfM8wxjzs3reMPD+THVDa32rw+oaHgfWdUVvhB94HFiWpb1UX+yX3fA48A0fcR8Yb+zrFwMQ3oM2qoeaAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbHorizontal_Pressed" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtwAAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAIElEQVQ4T2P4//8/A7GYaIUgA0cVIwfraGiMhgaubAYAL92Riw/41HQAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA6wAAAAKJUE5HDQoaCgAAAA1JSERSAAAACwAAABQIBgAAAFssx2gAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAVElEQVQ4T2P4z8Dwn1jMAFZIDACqG1UMD6jR0EBOM7DQOHPmDN6kBJYHKwZSIAYuDTCFIHUQxTg0ICtEVYymAV0hpmJkDZBMgbAZxRnIElgUgjQCAM5S6cxKR1AkAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbVertical_HotTracked" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAH0lEQVQ4T2P4//8/AzUxVQ0DOWzUQMojaDQMB2EYAgCgupGLAwHAdQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA5wAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAUElEQVQ4T63TUQoAIAgDUK/rXb2TsaioQT+6YF/RQ9HM3bOazDSOAaue9fZBWyAKYbQNMioBb1QGRsRsXwJuDBNvgzfWBhk7IC4q+e6h8qcMGejvq+vnDHQAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbVertical_Normal" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAH0lEQVQ4T2P4//8/AzUxVQ0DOWzUQMojaDQMB2EYAgCgupGLAwHAdQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAAgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAa0lEQVQ4T63TQQoAIQhAUa/bXTuH0CIIhEAIHBSKkJmNzuKvokdgQilFookI+ECxtVYovfsKMrNE86i9cM6Z6kYNJKJ0GzVwjJGu1mrDNbD3nmpjOiADW2vhbuyAiCiRPHZAPYj0+Q//3JQH56zbto7S08kAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_TrackBarThumbVertical_Pressed" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Centered" backGradientStyle="None" backHatchStyle="None">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAH0lEQVQ4T2P4//8/AzUxVQ0DOWzUQMojaDQMB2EYAgCgupGLAwHAdQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA7AAAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAAAsIBgAAAH8JrUMAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAVUlEQVQ4T63TQQoAIAgEQP//Nv9kplQqnVyDPYVDWZIQSTtaKSVkWHd5bUIx0LiM4mBBZ8CAjoHMbNcfAQ/mHUVeWYWIwWDFLrg3Oqlf5p2wOy2fSVlV/ORrFqyiFwAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="Default_UltraSplitterButtonDockedBottom_Horizontal_HotTracked" backColor="Red" foreColor="White" borderColor="Silver" backColor2="218, 0, 0" backGradientStyle="Horizontal" />
    <resource name="Default_UltraSplitterButtonDockedBottom_Horizontal_Normal" backColor="252, 252, 252" foreColor="218, 0, 0" borderColor="Silver" backColor2="225, 225, 225" backGradientStyle="Vertical" />
    <resource name="Default_UltraSplitterButtonDockedRight_Vertical_HotTracked" backColor="218, 0, 0" foreColor="White" borderColor="Silver" backColor2="Red" backGradientStyle="Horizontal" />
    <resource name="Default_UltraSplitterButtonDockedRight_Vertical_Normal" backColor="252, 252, 252" foreColor="218, 0, 0" borderColor="Silver" backColor2="225, 225, 225" backGradientStyle="Horizontal" />
    <resource name="ExplorerBarGroupHeader_HotTracked" colorCategory="Primary Color" backColor="Transparent" foreColor="White" imageBackgroundStyle="Stretched" borderAlpha="Transparent" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="4, 0, 4, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAHwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMwAAAB4IBgAAAIGTJsIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAiElEQVRYR93YUQpBARQG4dn/DhERIroiRMQ1tjEP33mf/rfDFMYKZsZUMDemgoUxFSyNqWBlTAVrYyrYGFPB1pgKdsZUsDemgoMxFRyNqWAwpoKTMRWcjangYkwFV2MquBlTwd2YCh7GVPA0poKXMRW8jangY0wFX2MqGI2paC1T+TP/O5h4Kn5ReHckUQzzoQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="GridHeader" colorCategory="{None}" backColor="180, 180, 180" imageBackgroundStyle="Stretched" fontBold="True" backGradientStyle="None" backHatchStyle="None">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAAwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAGQAAABQIBgAAAHh3lr0AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAbElEQVRIS7XVUQpAEQBE0dn/qmxFRCQiIql5vUXMx/m9vxfGGKrhvUc13HuphnMO1bD3phrWWlTDnJNqGGNQDb13qqG1RjXUWqmGUgrVkHOmGlJKVEOMkWoIIVAN3nuqwTlHNVhrqQb1ev/+BytWS8ydS/orAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="HistoryButtn" imageHAlign="Right" imageVAlign="Middle" imageBackgroundStyle="Centered">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAzQAAAAKJUE5HDQoaCgAAAA1JSERSAAAADQAAAA4IBgAAAPR/ltIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAAANklEQVQoU2P4//8/A6mYZA0gC4a9JmNj42AgvoeGu9BDFyMg0DRiaMAZelCNWDWMiCAnNuECAMU1Cxgm9LVnAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAEQIAAAKJUE5HDQoaCgAAAA1JSERSAAAAGAAAABUIBgAAAFzpLiYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAA6+AAAOvgHqQrHAAAABeklEQVRIS52V7a7BQBCG3Yi4Qxd0XIrqhyZthDZFSS0pQSQkiIqISM6ceeVs4kcx68cTEWuendndmQoRVZrNZqXdbsf8Sd/QarV+fd93EQfxnnl8wQ//EsWLaTAYUJqmIobDIUVRRLZtE0vsUsGzhBcphkajEY3HYzGQIJOXAi3pdDpVx3HuvV6PsiwTg82gvG8FWhKG4Y/ruo/gSikxYgHOA1n0+32azWZiRAKdRRAEEWdCeZ6LMRJ0u92653m0WCzEGAniOK7iyi6XSzFGApyDZVm0Xq/FfCXYbDYkBRv6eE31IfMNquF1brdbMUaCJEnq3J9ot9uJMRLwLYrwmvf7vRiR4Knx3efzOR2PRzEfBTo4l6eBhnc4HOh0OokRCbhp1bj29+l0Sufz2Yi3Ar17rr1C60Xwy+UipigKeinQwflQFfoPFl+vVyPw4rlBls+DyWRS08FR99vtJgZZrlYrQnvnsyufaDweG6j7N/MY/8HO+WE6ZTP5D4GDetLe3csWAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="RedForeground" colorCategory="Primary Color" foreColor="248, 0, 0" />
    <resource name="RedGripHor" colorCategory="Primary Color" imageBackgroundStretchMargins="10, 5, 10, 6">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgAAAAKJUE5HDQoaCgAAAA1JSERSAAAABQAAAAYIBgAAAAv7VEsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAH0lEQVQYV2P4z8DwHwgYkGkUDkwSpAwD41CJ1Uws2gG9vU2z/WcBEQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
    </resource>
    <resource name="RedGripVertial" colorCategory="Primary Color" imageBackgroundStretchMargins="7, 7, 7, 7">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsQAAAAKJUE5HDQoaCgAAAA1JSERSAAAABgAAAAUIBgAAAGZYneYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAGklEQVQYV2P4z8DwH4yBJDIbJIIVo6iiTAcA/H1NszXUBVEAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
    </resource>
    <resource name="scrollBarThumbHorizontal_HotTracked" colorCategory="{None}" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="10, 5, 10, 6">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA7wEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIAAAAA8IBgAAAIWAzRcAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABWElEQVRIS72VUYuCQBSF/SG77P/O/RWaYWgqRBIRGUKJiD4I4otv0RAK3Z0jO4tWsw+ubnBeGu853x2uV4WIlK40TVOm1GNeLxyHIvx4PH66rst0Xaf5fD5YqIcP91O7jQmQHwBxGEXRBwosy6I8z+l2u/Fnh/3u9zsxxihNU0C0IPBHlhQAD+33e2qaZliqpAqN7Ha7FkI0C4jeDRwOBxWdg7qu69F1vV7Jtm3iOTNxCz2A1WrFkiShy+UymcIwJOS8BMDAlGVJVVVNJswVcqQARVHQlPoVgFNRHMeUZdlkOp1O8hswTZP5vk/n83kyrddrQo5sCGeLxQJTSkEQjC74YqnxIWyX0tNriD85AFsul7TZbGi73Y4m+PHOCf7SPYADHv7OKdsVDBDHccjzvMFCPXy+Vzqae3u5CcVqFHSGYai8CLR4Zf4k+MCv2/nTKv6vL+Lj1/ALLCT7+Ln9DqwAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="scrollBarThumbHorizontal_Normal" colorCategory="{None}" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="10, 5, 10, 5">
      <image>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtwAAAAKJUE5HDQoaCgAAAA1JSERSAAAABQAAAAYIBgAAAAv7VEsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAIElEQVQYV2MwNjb+DwQMyDQKBybJAGKgY+wqsZqJTTsAT+pI6xrX34gAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</image>
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA+AEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIAAAAA8IBgAAAIWAzRcAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABYUlEQVRIS72VX4uCQBTF+yC77Peu/RSWFZpEPYX0VwWhFKyHFOqllykIOjtn2Fn6oy+mK5wXZ+49v3t17jQANO5lGEajTj37PZhzUZsvl8vv4XAo2u02Op1OaTGeeWS+1n1hGuQPQC+GYfjFANu2sdvtcLlc5N5yz+12gxACcRwTQoEwP70KAbhpOp3ier2Wcy2IYiGu6yoIXSwhHjown89brPx8PiuAqsVuDAYDLBaLpu7CA4DjOILt4sa6FAQB6JMLwB/mcDjgdDrVpjRNQZ9CgOPxiDqVZVkxgKRCkiTY7/e1KYqiYgDLstQJ2G63tWkymYA+uZ9gPB43e70eNpsNSFq11us1TNOE9FFD6eUY8mW/3xfyL4Xv+5BDozJ5nqeOIPMXzgEujEajT9kF8UuK2WyG1WpVWoyXOVXlzCur/8idhHo0ajpJ2+p2u6TlkXlLzMN895W/jOL/uhGfb8Mf2PQRo9b/c14AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="scrollBarThumbVertical_HotTracked" colorCategory="{None}" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 10, 0, 10">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA+gEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAACAIBgAAAM0sIqkAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABY0lEQVRIS+2VT6uCQBTF/SK9973rrRKkkkxdCBbVIqS0QNxEoBsX/gHdWDDb++ZemFB6lczuQYtx4fi793iZOUcBAEV2SYPY8A6Px2Olz2qrfIBt2x7NZjPGC4GqqrTm8znbbDY/orgoQDC+dBznezqdMr5gvV5DFEWQJAnEcQzH4xEmkwksFgt2Op2+RJG7VARN0wS+SeD5fCY4TVPI8xyyLIPlcgn8G1RFHD1QKlY+HA5P4aqqoK5rQGWe543uMHZdrVYEPuuMcNM0EIYhWJZF3YVsCIKgF1wUBQ2xA4uu7zpfr1d5mDH2gfEc9532Z2D8gONZlR7Y/4Bvt9vjxfB9X+4+o5OgP/VxEjTDjpMID9vv9y9tqCxLMAwDPWzYdhIFu+PGK/fk9tx1z5ZvD7CApmngui4VuVwuZMG73Q50XSff5rIH2PXPuOG/MMTEEGkhEmO73ZLUdmp0gk46q2Ri9hdH3cqhNYRtTwAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbVertical_Normal" colorCategory="{None}" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="7, 7, 7, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gEAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAACAIBgAAAM0sIqkAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABX0lEQVRIS+2Vv46CQBDGeRHv3lvvKSSgoIAQE438CVRioAESKgugWAo0czt7WYLhNHt0l1gMBclvvm8H9hsJAKSpNRlEwR5eLpeSSA1djuDdbrfQNI3QRiDLMivDMIjneV+8OW/AYHxpWdbnarUi6/UaTqcTpGkKZVmyiuMY8L1pmuRyuXzwJr1VVVXJdruF8/nMwCzLGHi9XqGua1bH4xGoCLpiHHtQaEFhCILgKUwIgbZtmYMwDBc9jKqO40AURS/hrusgSZJendsG13WFYLSPQ+yVcbJ0mkLw7XabDtOv84b/Mu33wH6ul/Dv+U8Hdr/fxxcDc0skDEb3GZPEtm0hGDOO51ifYYqigO/7L2OoaRqMYcyw+TBJJFTfbDZP4aqqYL/fP6bnILdnmNvo4HA4sKwuigLyPEcl0HWd5Ta1PUPVX9cNPfscNwbfFnxj0CMxq8Ot8bDoJu+qKWv2G3L+BAGOQx2UAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="scrollBarTrackHorizontal_Normal" colorCategory="{None}" backColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="7, 0, 8, 0">
      <imageBackground>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</imageBackground>
    </resource>
    <resource name="scrollBarTrackVertical_Normal" colorCategory="{None}" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 13, 0, 13">
      <imageBackground>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</imageBackground>
    </resource>
    <resource name="SplitterBarHorizontal" colorCategory="{None}" backColor="240, 240, 240" backColor2="209, 209, 0" backGradientStyle="Horizontal">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAugAAAAKJUE5HDQoaCgAAAA1JSERSAAAABQAAAAoIBgAAAHw5lDAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAI0lEQVQYV2M4cODA//v37/+/fv36/3Pnzv1fv379f4ahLAgAEtWoSeRy5wsAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="SplitterBarVertical" colorCategory="{None}" backColor="240, 240, 240" imageBackgroundStyle="Stretched" backColor2="180, 180, 180" backGradientStyle="Vertical" imageBackgroundStretchMargins="0, 1, 0, 1">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAwQAAAAKJUE5HDQoaCgAAAA1JSERSAAAACgAAAAUIBgAAAHxkfWgAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAKklEQVQYV43DMQ0AAAwCMPx74p0UHg4kMAs0Ke6uSyTpEra7hKQuQbLLB52ssam9KXSjAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TabBottomBG" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 1, 0, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArgAAAAKJUE5HDQoaCgAAAA1JSERSAAAABAAAAAUIBgAAAGKtTdsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAF0lEQVQYV2P4yMDwHxkz/P//HwWTIQAAwuE3kfBs6VcAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TabItemHorizontalBottom_HotTracked" colorCategory="Primary Color" backColor="Transparent" foreColor="Black" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="5, 0, 5, 6">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAwAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHQAAAB4IBgAAANAHFaEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABKUlEQVRIS8XWu46CQBiG4fHQq/3uTdjZeEMW3o6FjYX3Y6KF2QgrsEA4D4cAAcK3TDb7X4H8TvImE4p5mGEKRDqZgHOk0ykEOzqbvRHt+x5cpf877boOXBHati24IrRpGnBFaF3X4IrQqqrAFaFlWYIrQouiAFeE5nkOrgjNsgxcESqlBFeEJkkCrgiN4xhcERpFEbgiNAgCcEWo7/vgilDP88AVoa7rgitCHccBV4Tatg2uCLUsC1wRapomuPpDh59f4/GAYRijZ97vSOdzCLlY9D/nM57P5+jZxyPkatWLcLv9CjcbfN9u0HV91KL1GsoT7n7/IZfLPhwemKcT9OsVmqa9LP1ygXU4QG1Mnaq7232KVAihJsHwBgpXH/qlDXdGYWp95SjvF7aIPTmxKwTvAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="TabItemHorizontalBottom_Selected" colorCategory="{None}" backColor="Transparent" borderColor="Transparent" fontBold="True" backGradientStyle="None" backHatchStyle="None" />
    <resource name="tabItemHorizontalBottomAppletini_Selected" colorCategory="Primary Color" backColor="Transparent" foreColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="7, 3, 7, 5">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAuQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHQAAAB4IBgAAANAHFaEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABIklEQVRIS73WwUqCQRTF8UFBfAhduxBfxPcQBBF8CV3qp5t8hCBKXEsQQSFCBBGIIoJQQQgSpCEf6PVcg/MEfmfx385v7swsJkSdjo1CkOVeUKPddvsfvcekqog+AFVF9BGoKqJPQFURHQNVRXQCVBXRF6CqiL4CVUX0Dagqou9AVRGdAlVFdAZUFdEFUFVEl0BVEV0BVUX0A6gqol9AVRH9BqqK6BqoKqIboKqI/gBVRfQXqCqiO6CqzmgXX9C/VMr2gJNum8lYz9GrVuv4mctZDDTp5sWi9ZvNY7irVufDSsXidNoOgJPsutEw98JzuZzvY9qbet1WhYLFOAIDfqn22awtSiW7rdXMT9W9EEXRGR5gBz66X/RFw5txzNd3x70TmdSRl1gL4FoAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="TabItemHorizontalTop_HotTracked" colorCategory="Primary Color" foreColor="Black" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="6, 6, 6, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAvgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHQAAAB4IBgAAANAHFaEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABJ0lEQVRIS8XXS27CMBSFYQMLAFbAOhjAjCkbgYUxQAxYC0KolZLm0TwaJ4qTKCTK4zRu1bsCcmvpm/rXtSVLFkoI4R8OK7nZvKfzea+mU7xaulj0en/d0T0RHI+rdLnsv/Z72JcLzMcDhmG8jHm7wTmdINdr6LjuCbndvkW7HUzTHNXH/Y5hWuie0FO61yssyxrd5/kMfYVCzWawh+O0bXt8w2mqyQQ/Ucdx2FDUdV1woajneeBCUd/3wYWiQRCAC0XDMAQXikZRBC4UlVKCC0XjOAYXiiZJAi4UTdMUXCiqlAKbv7c3yzJwoUnzPAcXihZFAS4ULcsSXCj6fD7BhaJVVYELReu6BheKNk0DLhRt2xZcKNp1Hbj8RodvRN/3bCgKxvVv0W+f8UETQg5CtgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TabItemHorizontalTop_Selected" colorCategory="Primary Color" backColor="Transparent" foreColor="White" borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="6, 6, 6, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHQAAAB4IBgAAANAHFaEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABIElEQVRIS73SzUpCURTF8YOKvoUX9G18B0dOLvgcOtTrSHuIFJo0iCAEQ4QIRIg+CCJRRJAggrJ0t7bBmjW7rsH/DPfvbM4JSZKE60ol6sfxY7fZ3HfabUu7Hub6fHfcO4Anjcb+vFq1ZRTZTy5nFkJqbQsFm5fLdlqvm+PuhUEcP5zVaqkh/134O583bGvuhR62XBSLtsN2x+61VDJ/wtBptewzm7Ut0GP3lclYgj/zhwJURfQDqCqi70BVEX0DqoroBqgqomugqoiugKoiugCqiugcqCqiL0BVEX0GqoroE1BVRO+BqiJ6B1QV0RlQVUSnQFURvQWqiugNUFVEJ0BVER0DVUV0BFQV0SFQVQfUjyugqoheAlVF9AKoKkd/AfgqmLJcUwfJAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="TabItemVerticalLeft_HotTracked" colorCategory="Primary Color" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="5, 5, 0, 5">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAqwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHgAAAB0IBgAAAL2k3AwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABFElEQVRIS+2XzYrCMBSFo+7VF5iZZ9CNuNAXcuHruBPxhQRddWhoY0tbmtL0h7a0NGeaMjMw+zGrBM7641zODeeSjBASHI/vfLf7FPO5zCYT6BAJDocPsVxKvtmAXa+wLQuUUjiOA9d1wRiD53nwfR9BECAMQ0RRhDiOwTlHkiRI0xRCCOR5jqIoUJYlqqpCXddomgZt26LrOvR9Dykl1CPxfm/x9Rr0fodt26O0gJVbdrn8QrWBs9nsj1ut4J8Rax21cmzAWlJtRm3W6WV/tQmXCZcJ179VH7NO+tZpOgW93fSXPbFYyOfppB889urtVj94uCTelOtktcLzfAZ9PPQU+vF2GuDKuSr3ar1epiFP2be+AOTPJEQfsXQdAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="tabItemVerticalLeft_Selected" colorCategory="Primary Color" foreColor="White" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="8, 5, 3, 6">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAlwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHgAAAB0IBgAAAL2k3AwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABAElEQVRIS+3XzwoBURQG8CvxDLORWHmWeQyl7mJeYywZK/MQorCTkiIpKSn5EymmpKRECMd3ZeEF5szCXfw2s/m6t9Pc7wjHcUTXNONlKefFbPbl5PPE4RPqIrCeTtPeMOgWCtFVCDrDCY5wgD3swIMNrGEJC5jCBMYwgiEMoA896EAbWtCEBoiKlLNqJkPPcJie+HAHlmDXtl9eIkGEQNbgQi5H92g0mGB12kBOrINZploNl75qfdW+/Kv1cLG9Tvqq9VX71rn+cLjQox+RCH/1USV+m0zyB6teXUOZZy972CRiapMoWRatUim6oOqyvMff3SmmTq7KvZpyv/zuZG83kJiLtYtwpAAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TabItemVerticalLeft_Selected" colorCategory="{None}" backColor="Transparent" foreColor="White" backGradientStyle="None" backHatchStyle="None" />
    <resource name="TabItemVerticalRight_HotTracked" colorCategory="Primary Color" foreColor="Black" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 5, 5, 5">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHgAAAB0IBgAAAL2k3AwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAABGUlEQVRIS+2XSW7CQBBFzbAH9olyAS7AAov7sOBCiB07TgOsCHY84EF2x+6WB9mW3T92lEg5QLqTRZdU6y9V//r9SmPjMdhkIranU9DFgpP1+jXYbl+Y1he+inOOruvQti2apkFd16iqCmVZoigK5HmOLMvAGAOlFGmaIkkSEEIQxzGiKEIYhgiCAL7vw/M8uK4Lx3FgGwYepxOIroPO53wQlyNs27AsC6ZpIt5sEOv6Tbqwu9+DzmZcurB5PmPwlXRho39vJSxunX64Wo0aQpNLjVoFiLBvUZlLmUuZ69co8z+sk3m5/A36uIfDJ1tLhb236xXvy6VErr7f8TgeQVar70viWWOjEYR3n1QDxPcnzC3Y7Z6G2+kDbTk6hdw1QbcAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="TabItemVerticalRight_HotTrackSelected" colorCategory="Primary Color" foreColor="241, 0, 0" />
    <resource name="TabLeftBG" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 0, 1, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArwAAAAKJUE5HDQoaCgAAAA1JSERSAAAABQAAAAQIBgAAAEYz9UAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAGElEQVQYV2P4//8/AzL+yMCAKgCSJE0QAFevN5E6LZ3WAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TabRightBG" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="1, 0, 0, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArAAAAAKJUE5HDQoaCgAAAA1JSERSAAAABQAAAAQIBgAAAEYz9UAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAFUlEQVQYV2P4yMDwHwhABBwzUCYIABRvN5GyKW18AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="tabtemVerticalRight_Selected" colorCategory="Primary Color" backColor="Transparent" foreColor="White" borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="5, 5, 5, 5">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAkwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAHgAAAB0IBgAAAL2k3AwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAA/ElEQVRIS+3X0QrBUBgH8FMrXoK0G8WTyIOslcs9w1za5oYncCXcS0nRUlJSMppWUlJSolnx+Z9deQA7Sufid7v/djr/9X3MtixyarVE1fH8pmm+Orq+mZTLOdu2GeszRtwAhjCCMbgwhRnMYQFLWMEatuBDAHs4wBFOcIYLXOEGd0WhQFUJwfEL8HAhwSHCI3hCT9Ooq+ue8GC/WKRGtfoSHvxIp8nBvRIeTDhuGZxYnT5vtTzqRP9c8qhlj2WPvzYIyDrJOv13naJfzVy7QoGaoqfMMJWilmGIm6v5JuHn89SuVOKvxSaRZXx3ShrvLR/iscJ4bqmU4bvTG4O3kcDbAtZcAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="TabTopBG" colorCategory="Primary Color" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 0, 0, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAsAAAAAKJUE5HDQoaCgAAAA1JSERSAAAABAAAAAUIBgAAAGKtTdsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAGUlEQVQYV2P4//8/AzJG4YAkiBD4CFSEjAHgwDeRPR1Q+wAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="TopRed" colorCategory="Primary Color" backColor="Red" foreColor="White" backGradientStyle="None" backHatchStyle="None">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAHwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAMwAAAB4IBgAAAIGTJsIAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsNAAALDQHtB8AsAAAAiElEQVRYR93YUQpBARQG4dn/DhERIroiRMQ1tjEP33mf/rfDFMYKZsZUMDemgoUxFSyNqWBlTAVrYyrYGFPB1pgKdsZUsDemgoMxFRyNqWAwpoKTMRWcjangYkwFV2MquBlTwd2YCh7GVPA0poKXMRW8jangY0wFX2MqGI2paC1T+TP/O5h4Kn5ReHckUQzzoQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
  </resources>
</styleLibrary>