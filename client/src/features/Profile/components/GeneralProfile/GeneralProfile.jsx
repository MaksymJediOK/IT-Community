import React from 'react'
import { Stack, Box } from '@mui/material'
import { ProfileFields } from './componets/ProfileFields'
import { AvatarBlock } from './componets/AvatarBlock'

export const GeneralProfile = () => {
	return (
		<>
			<Box sx={{ p: '24px 48px 135px 24px' }}>
				<Stack direction='row' justifyContent='space-between'>
					<ProfileFields />
					<AvatarBlock />
				</Stack>
			</Box>
		</>
	)
}
