import React from 'react'
import { Outlet } from 'react-router-dom'
import styled from '@emotion/styled'
import { Stack } from '@mui/material'

const LogoText = styled.div`
	font-size: 93px;
	color: #f1f1f1;
	text-transform: uppercase;
  line-height: 100%;
`

const Footer = styled.div`
	flex-shrink: 0;
`
const PageContainer = styled.div`
	margin: 0;
	display: flex;
	flex-direction: column;
	min-height: 100vh;
`
const ContentWrapper = styled.div`
	flex-grow: 1;
`

export const AuthLayout = () => {
	return (
		<>
			<PageContainer>
				<Stack direction='row' spacing={6} sx={{ overflow: 'hidden', mt:'20px' }}>
					<LogoText>itroom</LogoText>
					<LogoText>itroom</LogoText>
					<LogoText>itroom</LogoText>
					<LogoText>itroom</LogoText>
					<LogoText>itroom</LogoText>
				</Stack>
				<ContentWrapper>
					<Outlet />
				</ContentWrapper>
				<Footer>
					<Stack direction='row' spacing={5} sx={{ overflow: 'hidden', mb:'20px '}}>
						<LogoText>itroom</LogoText>
						<LogoText>itroom</LogoText>
						<LogoText>itroom</LogoText>
						<LogoText>itroom</LogoText>
						<LogoText>itroom</LogoText>
					</Stack>
				</Footer>
			</PageContainer>
		</>
	)
}
