import React from 'react'
import { Avatar, IconButton, Stack } from '@mui/material'
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined'
import NotificationsNoneOutlinedIcon from '@mui/icons-material/NotificationsNoneOutlined'
import { useNavigate } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { setAnchor } from '../../features/Popover'

export const UserBar = () => {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	return (
		<Stack direction='row' spacing={3}>
			<IconButton onClick={() => navigate('/articles/new')}>
				<ModeEditOutlineOutlinedIcon />
			</IconButton>
			<IconButton>
				<NotificationsNoneOutlinedIcon />
			</IconButton>
			<Avatar
				sx={{ width: '40px', height: '40px', cursor: 'pointer' }}
				onClick={(e) => dispatch(setAnchor(e.currentTarget))}
			/>
		</Stack>
	)
}
