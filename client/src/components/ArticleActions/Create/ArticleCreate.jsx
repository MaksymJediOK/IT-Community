import React, { useState } from 'react'
import styles from './ArticleCreate.module.scss'
import { Container, Grid, Box, TextField, Button, TextareaAutosize, Stack } from '@mui/material'
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline'
import Select from 'react-select'
import { useForm, Controller } from 'react-hook-form'
import { useGetAllTagsQuery } from '../../../services/tagsApi'
import { useCreateArticleMutation } from '../../../services/articleApi'
import { selectMap } from '../../../utils/SelectMap'
import { useNavigate } from 'react-router-dom'
import { setErrors } from '../../../store/reducers/articleActionSlice'
import { useDispatch } from 'react-redux'

export const ArticleCreate = () => {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	const { data } = useGetAllTagsQuery()
	const [createArticle] = useCreateArticleMutation()
	const [file, setFile] = useState(null)
	const { handleSubmit, control } = useForm({
		mode: 'onBlur',
	})
	const options = selectMap(data)
	const selectFile = (e) => {
		setFile(e.target.files[0])
	}

	const handleOnSubmit = (data) => {
		const { title, desc, body, options = [] } = data
		const formData = new FormData()
		formData.append('Title', title)
		formData.append('Description', desc)
		formData.append('Body', body)
		formData.append('ImageFile', file)
		options.forEach((item) => {
			formData.append('TagsId', `${item}`)
		})
		formData.append('ForumId', `${1}`)
		createArticle(formData)
			.unwrap()
			.then(() => navigate('/articles'))
			.catch((error) => {
				// not finished check if error exist
				dispatch(setErrors(error.data?.errors))
			})
	}

	return (
		<Container sx={{ marginTop: '32px' }}>
			<Box component='form' onSubmit={handleSubmit(handleOnSubmit)}>
				<Grid container spacing={3}>
					<Grid item xs={8}>
						<div className={styles.title}>Share your ideas</div>
						<div className={styles.create_container}>
							<Box sx={{ margin: '24px 0 0 24px' }}>
								<Controller
									control={control}
									name='title'
									defaultValue=''
									render={({ field }) => (
										<TextField
											{...field}
											label='Title'
											variant='standard'
											sx={{ width: '600px' }}
											inputProps={{ style: { fontSize: '32px' } }}
											InputLabelProps={{
												style: { fontSize: '32px', fontWeight: '900' },
											}}
										/>
									)}
								/>
								<Controller
									control={control}
									name='desc'
									defaultValue=''
									render={({ field }) => (
										<TextField
											{...field}
											label='About'
											variant='standard'
											helperText='What your story is about in a short sentence'
											sx={{ width: '400px', margin: '12px 0 32px 0' }}
											inputProps={{ style: { fontSize: '20px' } }}
											InputLabelProps={{
												style: {
													fontSize: '20px',
													fontWeight: '500',
													opacity: '0.5',
													letterSpacing: '0.15px',
													paddingBottom: '5px',
												},
											}}
										/>
									)}
								/>
								<Stack sx={{ m: '10px 0 30px' }}>
									<div className={styles.upload_text}>
										Upload thumbnail for your article
									</div>
									<input type='file' onChange={selectFile} />
								</Stack>
								<Controller
									control={control}
									name='body'
									defaultValue=''
									render={({ field }) => (
										<TextareaAutosize
											{...field}
											minRows={3}
											style={{
												width: '600px',
												fontSize: '20px',
												fontWeight: '500',
												opacity: '0.5',
												letterSpacing: '0.15px',
											}}
											aria-label='Body'
											placeholder='Tell the world about your investigation'
										/>
									)}
								/>

								<Box
									sx={{ display: 'flex', alignItems: 'center', paddingBottom: '44px' }}
								>
									<AddCircleOutlineIcon />
									<div className={styles.add_block_text}>Add another block</div>
								</Box>
							</Box>
						</div>
					</Grid>
					<Grid item xs={4}>
						<div className={styles.title}>Configure</div>
						<div className={styles.help_text}>
							Help us sort your story in the right categories
						</div>

						<Controller
							control={control}
							name='options'
							render={({ field: { onChange, value, ref } }) => (
								<Select
									inputRef={ref}
									onChange={(val) => onChange(val.map((c) => c.value))}
									options={options}
									isMulti
								/>
							)}
						/>
						<Button
							type='submit'
							fullWidth
							variant='outlined'
							size='large'
							sx={{ mt: '24px' }}
						>
							{' '}
							PUBLISH{' '}
						</Button>
					</Grid>
				</Grid>
			</Box>
		</Container>
	)
}
