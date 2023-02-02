import React from 'react'
import styles from './ArticleList.module.scss'
import {
	Button,
	FormControl,
	Grid,
	IconButton,
	InputAdornment,
	InputLabel,
	OutlinedInput,
	Stack,
	Box
} from '@mui/material'
import SearchIcon from '@mui/icons-material/Search'
import { ArticlePreview } from '../Preview/ArticlePreview'
import { useGetArticlesListQuery } from 'services/articleApi'
import { ArticleListSkeleton } from './ArticleListSkeleton'
import Select from 'react-select';

export const ArticleList = () => {
	const { data = [], isLoading } = useGetArticlesListQuery()

	const options = [
		{ value: 'chocolate', label: 'Filter by' },
		{ value: 'strawberry', label: 'Date' },
		{ value: 'vanilla', label: 'Tags' }
	]
	return (
		<>
			<h2 className={styles.title}>Articles</h2>
			<div className={styles.container}>
				<FormControl sx={{ m: 1, width: '25ch' }} variant='outlined'>
					{/*<InputLabel htmlFor='outlined-adornment' >Search</InputLabel>*/}
					<OutlinedInput
						id='outlined-adornment'
						type='text'
						size='small'
						sx={{ width: '368px' }}
						endAdornment={
							<InputAdornment position='end'>
								<IconButton aria-label='toggle password visibility' edge='end'>
									<SearchIcon />
								</IconButton>
							</InputAdornment>
						}
						// label='Search'
					/>
				</FormControl>
				<Stack direction='row' spacing={3}>
					<Box sx={{ minWidth: 172 }}>
						<Select
							options={options}
							defaultValue={options[0]}
							theme={(theme) => ({
								...theme,
								borderRadius: 4,
								colors: {
									...theme.colors,
									primary: 'black',
								},
							})}
							styles={{
								control: (baseStyles, state) => ({
									...baseStyles,
									borderColor: state.isFocused ? 'grey' : 'black',
								}),
							}}
						/>
					</Box>
					<Box sx={{ minWidth: 172 }}>
						<Select
							options={options}
							defaultValue={options[0]}
							theme={(theme) => ({
								...theme,
								borderRadius: 4,
								colors: {
									...theme.colors,
									primary: 'black',
								},
							})}
							styles={{
								control: (baseStyles, state) => ({
									...baseStyles,
									borderColor: state.isFocused ? 'grey' : 'black',
								}),
							}}
						/>
					</Box>
				</Stack>
			</div>
			<Grid container spacing={2} sx={{ marginLeft: '-10px', marginTop: '10px' }}>
				<>
					{isLoading ? (
						<ArticleListSkeleton />
					) : (
						data.map((item) => {
							return <ArticlePreview key={item.id} {...item} />
						})
					)}
				</>
			</Grid>
		</>
	)
}
