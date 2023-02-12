import React from 'react'
import styles from './SingleVacancy.module.scss'
import { Box, Stack } from '@mui/material'
import BookmarkAddOutlinedIcon from '@mui/icons-material/BookmarkAddOutlined'

export const SingleVacancy = () => {
	return (
		<div className={styles.card}>
			<Stack direction='row' alignItems='center'>
				<Box sx={{ width: '36px', height: '36px', background: 'grey' }}></Box>
				<Stack spacing={1} sx={{ ml: '20px' }}>
					<div className={styles.card_title}> Junior Full Stack Developer</div>
					<div className={styles.card_company}> by EPAM UKRAINE</div>
				</Stack>
				<div className={styles.card_location}>Kyiv (Remote)</div>
				<div className={styles.card_date}>Sep 12, 2022</div>
				<BookmarkAddOutlinedIcon sx={{ width: '28px', height: '28px', ml: '100px' }} />
			</Stack>
		</div>
	)
}
