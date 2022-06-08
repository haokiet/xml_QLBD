<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<THONGKE>
			<MACLB>
				<xsl:value-of select="QLBD/BANGXH/MACLB"/>
			</MACLB>
			<NAM>
				<xsl:value-of select="QLBD/BANGXH/NAM"/>
			</NAM>
			<VONG>
				<xsl:value-of select="QLBD/BANGXH/MACLB/VONG"/>
			</VONG>
			<SOTRAN>
				<xsl:value-of select="QLBD/BANGXH/MACLB/SOTRAN"/>
			</SOTRAN>
			<THANG>
				<xsl:value-of select="QLBD/BANGXH/MACLB/THANG"/>
			</THANG>
			<HOA>
				<xsl:value-of select="QLBD/BANGXH/MACLB/HOA"/>
			</HOA>
			<THUA>
				<xsl:value-of select="QLBD/BANGXH/MACLB/THUA"/>
			</THUA>
			<DIEM>
				<xsl:value-of select="QLBD/BANGXH/DIEM"/>
			</DIEM>
			<HIEUSO>
				<xsl:value-of select="QLBD/BANGXH/MACLB/HIEUSO"/>
			</HIEUSO>
			<HANG>
				<xsl:value-of select="QLBD/BANGXH/MACLB/HANG"/>
			</HANG>
		</THONGKE>
	</xsl:template>
</xsl:stylesheet>
