import React, { useState } from 'react'
import styles from './ArticleList.module.scss'
import { FormControl, Grid, IconButton, InputAdornment, OutlinedInput, Stack, Box } from '@mui/material'
import SearchIcon from '@mui/icons-material/Search'
import { useGetArticlesListQuery } from 'services/articleApi'
import { ArticlePreview } from '../../ArticlePreview/ArticlePreview'
import { ArticleListSkeleton } from './ArticleListSkeleton'
import Select from 'react-select'
import { sortOptions } from 'utils/options'
import { FilterDrawer } from './FilterDrawer'
import { useSelector, useDispatch } from 'react-redux'
import { setSort, setSearch } from 'store/reducers/filterSlice'

export const ArticleList = () => {
	const [currentSearch, setCurrentSearch] = useState('')
	const dispatch = useDispatch()
	const filters = useSelector((state) => state.filter)
	const { data = [], isLoading } = useGetArticlesListQuery(filters)

	const handleSortBy = (data) => dispatch(setSort(data.value))
	const handleSearch = (data) => dispatch(setSearch(data))

	return (
		<>
			<h2 className={styles.title}>Articles</h2>
			<div className={styles.container}>
				<FormControl sx={{ m: 1, width: '25ch' }} variant='outlined'>
					<OutlinedInput
						onChange={(e) => setCurrentSearch(e.target.value)}
						id='outlined-adornment'
						type='text'
						size='small'
						placeholder='Search'
						sx={{ width: '368px' }}
						endAdornment={
							<InputAdornment position='end'>
								<IconButton edge='end' onClick={() => handleSearch(currentSearch)}>
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
						<FilterDrawer />
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
