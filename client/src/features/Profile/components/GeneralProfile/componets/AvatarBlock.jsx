import React from 'react'
import { Avatar, Button, Stack } from '@mui/material'

export const AvatarBlock = () => {
	return (
		<Stack sx={{ width: '150px' }}>
			<Avatar sx={{ width: '150px', height: '150px' }} />
			<Button variant='contained' sx={{ m: '24px 0 12px' }} fullWidth>
				UPLOAD
			</Button>
			<Button variant='outlined' fullWidth>REMOVE</Button>
		</Stack>
	)
}
