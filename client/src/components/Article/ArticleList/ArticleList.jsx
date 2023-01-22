import React from 'react'
import styles from './ArticleList.module.scss'
import {
	Button,
	FormControl, Grid,
	IconButton,
	InputAdornment,
	InputLabel,
	OutlinedInput,
	Stack
} from '@mui/material';
import SearchIcon from '@mui/icons-material/Search'
import ExpandMoreIcon from '@mui/icons-material/ExpandMore'
import { ArticlePreview } from '../ArticlePreview/ArticlePreview'

export const ArticleList = () => {
	return (
		<>
			<h2 className={styles.title}>Articles</h2>
			<div className={styles.container}>
				<FormControl sx={{ m: 1, width: '25ch' }} variant='outlined'>
					<InputLabel htmlFor='outlined-adornment-password'>Search</InputLabel>
					<OutlinedInput
						id='outlined-adornment-password'
						type='text'
						sx={{ width: '368px', ':hover': { borderColor: '#111' } }}
						endAdornment={
							<InputAdornment position='end'>
								<IconButton aria-label='toggle password visibility' edge='end'>
									<SearchIcon />
								</IconButton>
							</InputAdornment>
						}
						label='Search'
					/>
				</FormControl>
				<Stack direction='row' spacing={3}>
					<Button
						className={styles.btn_border}
						variant='outlined'
						size='medium'
						endIcon={<ExpandMoreIcon />}
						sx={{border: '1px solid #111', color: '#111'}}
					>
						SORT BY
					</Button>
					<Button
						className={styles.btn_border}
						variant='outlined'
						size='medium'
						endIcon={<ExpandMoreIcon />}
						sx={{border: '1px solid #111', color: '#111'}}
					>
						FILTER BY
					</Button>
				</Stack>
			</div>
			{/*Render dynamically in future*/}
			<Grid container spacing={2} sx={{marginLeft: '-10px',marginTop: '10px'}}>
				<ArticlePreview />
				<ArticlePreview />
				<ArticlePreview />
				<ArticlePreview />
			</Grid>

		</>
	)
}
