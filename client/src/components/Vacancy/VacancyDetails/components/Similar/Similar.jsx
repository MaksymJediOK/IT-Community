import React from 'react'
import styles from './Similar.module.scss'
import { Avatar, Button, Stack, Box } from '@mui/material'
import { SmallVacancyCard } from '../../../../UI/SmallVacancyCard/SmallVacancyCard'

export const Similar = () => {
	const data = {
		position: 'Junior Full Stack Developer',
		company: 'by EPAM UKRAINE',
		date: 'Sep 12, 2022',
	}
	return (
		<>
			<Stack direction='row' alignItems='center' sx={{ mb: '24px' }}>
				<Avatar sx={{ width: '48px', height: '48px' }} />
				<Stack spacing={1} sx={{ ml: '16px' }}>
					<div className={styles.recruiter_title}>Yevgeniy Olkesuiuk</div>
					<div className={styles.recruiter_pos}>Head Designer at EPAM UKRAINE</div>
				</Stack>
			</Stack>
			<Button variant='outlined' size='small'>
				SHOW CONTACTS
			</Button>
			<Box sx={{ mt: '64px' }}>
				<Stack
					direction='row'
					alignItems='center'
					justifyContent='space-between'
					sx={{ mb: '24px' }}
				>
					<div className={styles.more_title}>More in EPAM UKRAINE</div>
					<div className={styles.seeMore}>See more</div>
				</Stack>
				{[1, 2, 3, 4].map((item) => {
					return <SmallVacancyCard key={item} {...data} />
				})}
			</Box>
			<Box sx={{ mt: '64px' }}>
				<Stack
					direction='row'
					alignItems='center'
					justifyContent='space-between'
					sx={{ mb: '24px' }}
				>
					<div className={styles.more_title}>More in EPAM UKRAINE</div>
					<div className={styles.seeMore}>See more</div>
				</Stack>
				{[1, 2, 3, 4].map((item) => {
					return <SmallVacancyCard key={item} {...data} />
				})}
			</Box>
		</>
	)
}
