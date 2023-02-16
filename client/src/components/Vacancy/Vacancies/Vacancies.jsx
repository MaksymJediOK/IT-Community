import React from 'react'
import { Container, Grid } from '@mui/material'
import { VacanciesList } from './VacanciesList/VacanciesList'
import { PopularVacancy } from './VacanciesList/PopularVacancy/PopularVacancy'

export const Vacancies = () => {

	return (
		<Container>
			<Grid container spacing={3} sx={{ mt: '0px!important' }}>
				<Grid item xs={8}>
					<VacanciesList />
				</Grid>
				<Grid item xs={4} sx={{ mt: '22px' }}>
					<PopularVacancy />
				</Grid>
			</Grid>
		</Container>
	)
}
