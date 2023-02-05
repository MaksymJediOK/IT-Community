import React, { useState } from 'react'
import styles from './ArticleList.module.scss'
import { FormControl, Grid, IconButton, InputAdornment, OutlinedInput, Stack, Box } from '@mui/material'
import SearchIcon from '@mui/icons-material/Search'
import { ArticlePreview } from '../Preview/ArticlePreview'
import { useGetArticlesListQuery } from 'services/articleApi'
import { ArticleListSkeleton } from './ArticleListSkeleton'
import Select from 'react-select'
import { sortOptions, filterOptions } from 'utils/options'

export const ArticleList = () => {
	const [filter, setFilter] = useState('')
	const [sort, setSort] = useState('')
	const [tags, setTags] = useState([])

	const { data = [], isLoading } = useGetArticlesListQuery({ filter, sort, tags })

	const handleFilterBy = (data) => setFilter(data.value)

	const handleSortBy = (data) => setSort(data.value)

	return (
		<>
			<h2 className={styles.title}>Articles</h2>
			<div className={styles.container}>
				<FormControl sx={{ m: 1, width: '25ch' }} variant='outlined'>
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
					/>
				</FormControl>
				<Stack direction='row' spacing={3}>
					<Box sx={{ minWidth: 172 }}>
						<Select
							onChange={handleSortBy}
							options={sortOptions}
							defaultValue={sortOptions[0]}
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
							onChange={handleFilterBy}
							options={filterOptions}
							defaultValue={filterOptions[0]}
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
