import React from 'react'
import styles from './ArticleEdit.module.scss'
import { Container, Grid, Box, TextField, Button } from '@mui/material'
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline'
import Select from 'react-select'

export const ArticleEdit = () => {
	const options = [
		{ value: 1, label: 'Design' },
		{ value: 2, label: 'Development' },
		{ value: 3, label: 'Product' },
	]

	const handleSelectChange = () => {}

	return (
		<Container sx={{ marginTop: '32px' }}>
			<Grid container spacing={3}>
				<Grid item xs={8}>
					<div className={styles.title}>Share your ideas</div>
					<div className={styles.create_container}>
						<Box sx={{ margin: '24px 0 0 24px' }}>
							<TextField
								label='Title'
								variant='standard'
								sx={{ width: '600px' }}
								inputProps={{ style: { fontSize: '32px' } }}
								InputLabelProps={{
									style: { fontSize: '32px', fontWeight: '900' },
								}}
							/>
							<TextField
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
							<TextField
								label='Tell your story'
								variant='standard'
								helperText='What your story is about in a short sentence'
								sx={{ width: '600px', marginBottom: '28px' }}
								inputProps={{ style: { fontSize: '16px' } }}
								InputLabelProps={{
									style: {
										fontSize: '16px',
										fontWeight: '500',
										opacity: '0.5',
										letterSpacing: '0.15px',
										paddingBottom: '5px',
									},
								}}
							/>
							<Box sx={{ display: 'flex', alignItems: 'center', paddingBottom: '44px' }}>
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

					<Select options={options} onChange={handleSelectChange} isMulti />
					<Button fullWidth variant='outlined' size='large' sx={{ mt: '24px' }}>
						{' '}
						PUBLISH{' '}
					</Button>
				</Grid>
			</Grid>
		</Container>
	)
}
