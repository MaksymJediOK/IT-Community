import React from 'react'
import styled from '@emotion/styled'
import { IconButton } from '@mui/material'

const IconWrapper = styled.div`
	margin-top: -36px;
	width: 36px;
	height: 36px;
	border-radius: 50%;
	background: #fff;
	position: relative;
	top: 47px;
	right: 0;
	left: 320px;

	z-index: 1000;

	display: flex;
	flex-wrap: wrap;
	align-content: center;
	justify-content: center;
`

export const IconLabel = ({ children }) => {
	return (
		<IconWrapper>
			<IconButton sx={{ color: '#000' }}>
				{children}
			</IconButton>
		</IconWrapper>
	)
}
