import React from 'react'
import styles from './PopoverContent.module.scss'
import { Box, Stack } from '@mui/material'
import PermIdentityIcon from '@mui/icons-material/PermIdentity'
import BookmarkBorderIcon from '@mui/icons-material/BookmarkBorder'
import EqualizerOutlinedIcon from '@mui/icons-material/EqualizerOutlined'
import { Link, useNavigate } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { closePopover } from '../../features/Popover'

export const PopoverContent = () => {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	const SignOut = () => {
		localStorage.setItem('token', '')
		navigate(0)
	}

	return (
		<Box sx={{ width: '260px' }}>
			<Box sx={{ p: '16px 24px' }}>
				<Stack spacing={2}>
					<Stack direction='row' alignItems='center'>
						<PermIdentityIcon sx={{ mr: '20px', opacity: 0.7 }} />
						<Link
							className={styles.text}
							to='/profile'
							onClick={() => dispatch(closePopover())}
						>
							Profile
						</Link>
					</Stack>
					<Stack direction='row' alignItems='center'>
						<BookmarkBorderIcon sx={{ mr: '20px', opacity: 0.7 }} />
						<Link
							className={styles.text}
							to='/profile/favorites'
							onClick={() => dispatch(closePopover())}
						>
							Favorites
						</Link>
					</Stack>
					<Stack direction='row' alignItems='center'>
						<EqualizerOutlinedIcon sx={{ mr: '20px', opacity: 0.7 }} />
						<Link
							className={styles.text}
							to='/profile'
						>
							Stats
						</Link>
					</Stack>
				</Stack>
			</Box>
			<div className={styles.line}></div>
			<Box sx={{ p: '16px 24px' }}>
				<Stack spacing={1.5}>
					<Link className={styles.text} to='/profile'>
						Settings
					</Link>
					<Link className={styles.text} to='/profile'>
						Refine recommendations
					</Link>
					<Link
						className={styles.text}
						to='/profile/publications'
						onClick={() => dispatch(closePopover())}
					>
						Manage publications
					</Link>
				</Stack>
			</Box>
			<div className={styles.line}></div>
			<Box sx={{ p: '16px 24px' }}>
				<Stack spacing={1.5}>
					<div className={styles.text} style={{ cursor: 'pointer' }} onClick={SignOut}>
						Sign out
					</div>
				</Stack>
			</Box>
		</Box>
	)
}
