import React from 'react'
import Select from 'react-select'
import { useGetAllTagsQuery } from 'services/tagsApi'
import { selectMap } from 'utils/SelectMap'
import { useDispatch, useSelector } from 'react-redux'
import { setTags } from 'store/reducers/filterSlice'
import { Skeleton } from '@mui/material'

export const TagsSelect = () => {
	const { data = [], isLoading } = useGetAllTagsQuery()
	const dispatch = useDispatch()
	const options = selectMap(data) || []
	const current = useSelector((state) => state.filter.tags)
	const handleOptions = (tags) => {
		const tagsArray = tags.map((item) => item.value)
		dispatch(setTags(tagsArray))
	}

	const saveTags = (currentTags = []) => {
		if (currentTags) {
			return options.filter((item) => currentTags.includes(item.value))
		}
	}

	return (
		<>
			{isLoading ? (
				<Skeleton variant='rounded' width={210} height={38} />
			) : (
				<Select
					options={options}
					placeholder='Tags'
					defaultValue={saveTags(current)}
					isMulti
					onChange={handleOptions}
				/>
			)}
		</>
	)
}
