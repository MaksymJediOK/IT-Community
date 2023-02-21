import React from 'react'
import { TextField, Box, Stack, Button } from '@mui/material'
import styled from '@emotion/styled'

const Label = styled.div`
	font-size: 14px;
	line-height: 120%;
	color: #000000;
	margin-bottom: 8px;
`

export const ProfileFields = () => {
	return (
		<Box component='form' sx={{ width: '344px' }}>
			<Box sx={{ mb: '24px' }}>
				<Label>Full name</Label>
				<TextField variant='outlined' size='small' label='Name' fullWidth />
			</Box>
			<Box sx={{ mb: '24px' }}>
				<Label>Job position</Label>
				<TextField variant='outlined' size='small' label='Position' fullWidth />
			</Box>
			<Box sx={{ mb: '24px' }}>
				<Label>Bio</Label>
				<TextField
					variant='outlined'
					size='small'
					label='Tell about yourself'
					inputProps={{ style: { height: '60px' } }}
					fullWidth
				/>
			</Box>
			<Box sx={{ mb: '24px' }}>
				<Label>Link here</Label>
				<TextField variant='outlined' size='small' label='Link here' fullWidth />
			</Box>
			<Stack direction='row' justifyContent='space-between' sx={{ mt: '64px' }}>
				<Button variant='contained' sx={{ width: '148px' }}>
					SAVE CHANGES
				</Button>
				<Button variant='outlined' sx={{ width: '102px' }}>
					DISCARD
				</Button>
			</Stack>
		</Box>
	)
}
