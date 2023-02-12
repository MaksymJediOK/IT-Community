import React from 'react'
import { Container, Grid } from '@mui/material'
import styles from './VacancyDetails.module.scss'
import { VacancyContent } from './components/VacancyContent/VacancyContent'
import { Similar } from './components/Similar/Similar'

export const VacancyDetails = () => {
	return (
		<Container sx={{ mt: '32px' }}>
			<div className={styles.crumbs}>IT ROOM / Vacancies</div>
			<Grid container spacing={3} sx={{ mt: '24px' }}>
				<Grid item xs={8}>
					<VacancyContent />
				</Grid>
				<Grid item xs={4}>
					<Similar />
				</Grid>
			</Grid>
		</Container>
	)
}
