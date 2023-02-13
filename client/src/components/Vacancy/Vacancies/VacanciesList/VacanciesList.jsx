import React from 'react'
import styles from './VacanciesList.module.scss'
import { Box, FormControl, IconButton, InputAdornment, OutlinedInput } from '@mui/material'
import SearchIcon from '@mui/icons-material/Search'
import { SingleVacancy } from './SingleVacancy/SingleVacancy'

export const VacanciesList = () => {
	return (
		<>
			<h3 className={styles.title}>Vacancies</h3>
			<FormControl fullWidth variant='outlined'>
				<OutlinedInput
					id='outlined-adornment'
					type='text'
					size='small'
					fullWidth
					placeholder='Search'
					endAdornment={
						<InputAdornment position='end'>
							<IconButton edge='end'>
								<SearchIcon />
							</IconButton>
						</InputAdornment>
					}
				/>
			</FormControl>
			<Box>
				<SingleVacancy />
				<SingleVacancy />
				<SingleVacancy />
				<SingleVacancy />
			</Box>
		</>
	)
}
