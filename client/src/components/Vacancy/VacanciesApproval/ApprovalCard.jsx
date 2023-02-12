import React from 'react'
import styles from './VacanciesApproval.module.scss'
import { Avatar, Stack, Box } from '@mui/material'
import ThumbUpOffAltOutlinedIcon from '@mui/icons-material/ThumbUpOffAltOutlined'
import ThumbDownAltOutlinedIcon from '@mui/icons-material/ThumbDownAltOutlined'

export const ApprovalCard = () => {
	return (
		<div className={styles.container}>
			<Stack
				direction='row'
				alignItems='center'
				sx={{ height: '38px' }}
			>
				<Avatar variant='square' sx={{ width: '36px', height: '36px' }}>
					N
				</Avatar>
				<Box sx={{ ml: '20px' }}>
					<div className={styles.pos}>Junior Full Stack Developer</div>
					<div className={styles.company}>by EPAM UKRAINE</div>
				</Box>
				<div className={styles.place}>Kyiv (Remote)</div>
				<div className={styles.date}>Sep 12, 2022</div>
				<Stack direction='row' gap='18px'>
					<ThumbUpOffAltOutlinedIcon sx={{ width: '28px', height: '28px' }} />
					<ThumbDownAltOutlinedIcon sx={{ width: '28px', height: '28px' }} />
				</Stack>
			</Stack>
		</div>
	)
}
