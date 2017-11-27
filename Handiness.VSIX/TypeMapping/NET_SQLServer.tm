<?xml version="1.0" encoding="utf-8"?>
<!--类型映射文件说明
    DbType 为数据库中的类型，
    MappingType 为映射后的类型，
    如果需要忽略数据库类型长度，请不要设置Length属性，或者设置为-1
    如果设置长度信息后框架会附加长度信息的匹配，
      -->
<TypeMapping xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Explain>.NET-SQLServer类型映射</Explain>
  <MappingNodes>
    <MappingNode DbType="bit" MappingType="Boolean"/>
    <MappingNode DbType="varchar" MappingType="String" />
    <MappingNode DbType="int" MappingType="Int32" />
    <MappingNode DbType="nvarchar" MappingType="String" />
    <MappingNode DbType="float" MappingType="Single" />
  </MappingNodes>
</TypeMapping>