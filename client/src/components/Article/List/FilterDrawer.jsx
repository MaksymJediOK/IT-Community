import React, { useState } from 'react'
import { Button, Drawer, Box } from '@mui/material'
import { filterOptions } from 'utils/options'
import Select from 'react-select'
import { TagsSelect } from './TagsSelect'
import { useDispatch, useSelector } from 'react-redux'
import { setFilter } from 'store/reducers/filterSlice'

export const FilterDrawer = () => {
	const [isOpen, setIsOpen] = useState(false)
	const dispatch = useDispatch()
	const currentOpt = useSelector((state) => state.filter.filter)

	const saveOptions = (filterOption = '') => {
		if (filterOption) {
			return filterOptions.filter((item) => item.value === filterOption)
		}
		return filterOptions[0]
	}
	const handleFilterBy = (data) => dispatch(setFilter(data.value))

	return (
		<>
			<Button variant='outlined' fullWidth onClick={() => setIsOpen(true)}>
				FILTER BY
			</Button>
			<Drawer anchor='left' open={isOpen} onClose={() => setIsOpen(false)}>
				<Box sx={{ p: '15px 30px' }}>
					<Box sx={{ width: '230px', mt: 5 }}>
						<Select
							onChange={handleFilterBy}
							options={filterOptions}
							defaultValue={saveOptions(currentOpt)}
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
					<Box sx={{ width: '230px', mt: 5 }}>
						<TagsSelect />
					</Box>
				</Box>
			</Drawer>
		</>
	)
}
