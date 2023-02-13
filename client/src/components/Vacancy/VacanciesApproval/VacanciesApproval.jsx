import React from 'react'
import styles from './VacanciesApproval.module.scss'
import { Container, FormControl, Grid, IconButton, InputAdornment, OutlinedInput } from '@mui/material'
import SearchIcon from '@mui/icons-material/Search'
import { ApprovalCard } from './ApprovalCard';

export const VacanciesApproval = () => {
	return (
		<Container>

			<Grid container spacing={3} sx={{mt: '12px'}}>
				<Grid item xs={8}>
					<div className={styles.title}>Vacancies</div>
					<FormControl variant='outlined' fullWidth sx={{mt: '24px'}}>
						<OutlinedInput
							id='outlined-adornment'
							type='text'
							size='small'
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
					<ApprovalCard />
					<ApprovalCard />
					<ApprovalCard />
					<ApprovalCard />
				</Grid>
				<Grid item xs={4}></Grid>
			</Grid>
		</Container>
	)
}
