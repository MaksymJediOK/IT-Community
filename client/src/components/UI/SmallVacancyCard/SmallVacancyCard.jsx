import React from 'react'
import styles from './SmallVacancyCard.module.scss'
import { Box, Stack } from '@mui/material'

export const SmallVacancyCard = ({ position, company, date }) => {
	return (
		<div className={styles.container}>
			<Stack direction='row' alignItems='center' justifyContent='space-between' sx={{height:'28px'}}>
				<Box>
					<div className={styles.title}>{position}</div>
					<div className={styles.company}>{company}</div>
				</Box>
				<div className={styles.date}>{date}</div>
			</Stack>
		</div>
	)
}
