import React from 'react'
import { Stack } from '@mui/material'
import styled from '@emotion/styled'

const ArticleError = styled.div`
	font-size: 20px;
	color: #7a1f1f;
	margin: 10px 0 7px;
`

export const ArticleErrorMsg = ({ children }) => {
	return (
		<Stack>
			<ArticleError>{children}</ArticleError>
		</Stack>
	)
}
