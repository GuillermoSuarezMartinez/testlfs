<?xml version="1.0" encoding="utf-8"?>
<styleLibrary>
  <annotation>
    <lastModified>2013-01-25T11:47:07</lastModified>
  </annotation>
  <styleSets defaultStyleSet="Default">
    <styleSet name="Default">
      <componentStyles>
        <componentStyle name="UltraCombo" headerStyle="WindowsVista" />
        <componentStyle name="UltraGrid" headerStyle="WindowsVista">
          <properties>
            <property name="RowSelectorHeaderStyle" colorCategory="{Default}">ExtendFirstColumn</property>
          </properties>
        </componentStyle>
      </componentStyles>
      <styles>
        <style role="Base">
          <states>
            <state name="Normal" themedElementAlpha="Transparent" />
          </states>
        </style>
        <style role="GridCell">
          <states>
            <state name="Normal" textVAlign="Middle" textTrimming="EllipsisCharacter" />
          </states>
        </style>
        <style role="GridColumnHeader">
          <states>
            <state name="Normal" textTrimming="EllipsisCharacterWithLineLimit" />
          </states>
        </style>
      </styles>
    </styleSet>
  </styleSets>
</styleLibrary>