import React from 'react'
import { Popover } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux'
import { closePopover } from '../reducer/popoverSlice'
import { PopoverContent } from '../../../components/PopoverContent/PopoverContent'

export const UserPopover = () => {
	const dispatch = useDispatch()
	const anchorEl = useSelector((state) => state.userPopover.anchor)
	const handleClose = () => {
		dispatch(closePopover())
	}
	const open = Boolean(anchorEl)
	return (
		<Popover
			open={open}
			anchorEl={anchorEl}
			onClose={handleClose}
			anchorOrigin={{
				vertical: 'bottom',
				horizontal: 'right',
			}}
			transformOrigin={{
				vertical: 'top',
				horizontal: 'right',
			}}
		>
			<PopoverContent />
		</Popover>
	)
}
