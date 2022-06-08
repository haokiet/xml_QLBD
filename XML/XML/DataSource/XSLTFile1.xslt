<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<html>
			<body>
				<div style="color:red;align-item:center;width: 1000px;margin: 0 auto;">
					<h1 style="color:red;text-align:center;">BẢNG XẾP HẠNG</h1>
					<table border="1" style="width: 100%;">
						<tr bgcolor="#9acd32" style="width:200px">
							<th style="text-align:center">STT</th>
							<th style="text-align:center;width:120px">Tên Câu Lạc Bộ</th>
							<th style="text-align:center;width:120px">Mùa Giải</th>
							<th style="text-align:center;width:120px">Tổng Số Vòng Đấu</th>
							<th style="text-align:center">Tổng Số Trận</th>
							<th style="text-align:center">Số Trận Thắng</th>
							<th style="text-align:center">Số Trận Thua</th>
							<th style="text-align:center">Số Trận Hòa</th>
							<th style="text-align:center">Hiệu Số</th>
							<th style="text-align:center">Điểm</th>
							<th style="text-align:center">Hạng</th>
						</tr>

						<xsl:for-each select="QLBD/BANGXH">
							<xsl:variable name="mACLB" select="MACLB"/>
							<tr>
								<td>
									<xsl:number format="1 "/>
								</td>
								<td>
									<xsl:value-of select="/QLBD/CAULACBO[MACLB = $mACLB]/TENCLB"/>
								</td>
								<td>
									<xsl:value-of select="NAM"/>
								</td>
								<td>
									<xsl:value-of select="VONG"/>
								</td>
								<td>
									<xsl:value-of select="SOTRAN"/>
								</td>
								<td>
									<xsl:value-of select="THANG"/>
								</td>
								<td>
									<xsl:value-of select="THUA"/>
								</td>
								<td>
									<xsl:value-of select="HOA"/>
								</td>
								<td>
									<xsl:value-of select='format-number(THANG - THUA, "#")'/>
								</td>
								<td>
									<xsl:value-of select="DIEM"/>
								</td>
								<td>
									<xsl:value-of select="HANG"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
