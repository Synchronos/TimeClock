<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" />
	<xsl:template match="/*">
		<style media="all" lang="en" type="text/css" />
		<table>
			<xsl:for-each select="./*">
				<tr>
					<xsl:for-each select="./*">
						<td>
							<xsl:value-of disable-output-escaping="yes" select="text()" />
						</td>
					</xsl:for-each>
				</tr>
			</xsl:for-each>
		</table>
	</xsl:template>
</xsl:stylesheet>