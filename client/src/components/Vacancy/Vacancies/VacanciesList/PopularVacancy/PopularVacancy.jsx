import React from 'react'
import Typography from '@mui/material/Typography'
import styles from './PopularVacancy.module.scss'
import { Avatar, Button, Box, Stack } from '@mui/material'

export const PopularVacancy = () => {
	return (
		<>
			<Typography
				variant='h5'
				align='left'
				fontSize={20}
				fontWeight={700}
				sx={{ pl: '12px', mb: '-10px' }}
			>
				Popular areas
			</Typography>
			<div className={styles.tags_container}>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>frontend</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>backend</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>marketing</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>management</div>
				</div>
			</div>
			<div className={styles.authors_container}>
				<div className={styles.authors_text}>
					<div className={styles.authors_text__title}>Popular companies</div>
					<div className={styles.authors_text__more}>See more suggestions</div>
				</div>
				<div className={styles.list}>
					<div className={styles.list_item}>
						<div className={styles.list_item_author}>
							<Avatar>N</Avatar>
							<div className={styles.list_item_author_block}>
								<div className={styles.list_item_author_name}>Name Surname</div>
								<div className={styles.list_item_author_desc}>
									Lead Designer at Soft <br /> 2nd line{' '}
								</div>
							</div>
						</div>
						<Button
							sx={{
								width: '73px',
								height: '30px',
							}}
							size='small'
							variant='outlined'
						>
							{' '}
							FOLLOW
						</Button>
					</div>
					<div className={styles.list_item}>
						<div className={styles.list_item_author}>
							<Avatar>N</Avatar>
							<div className={styles.list_item_author_block}>
								<div className={styles.list_item_author_name}>Name Surname</div>
								<div className={styles.list_item_author_desc}>
									Lead Designer at Soft <br /> 2nd line{' '}
								</div>
							</div>
						</div>
						<Button
							sx={{
								width: '73px',
								height: '30px',
							}}
							size='small'
							variant='outlined'
						>
							{' '}
							FOLLOW
						</Button>
					</div>
					<div className={styles.list_item}>
						<div className={styles.list_item_author}>
							<Avatar>N</Avatar>
							<div className={styles.list_item_author_block}>
								<div className={styles.list_item_author_name}>Name Surname</div>
								<div className={styles.list_item_author_desc}>
									Lead Designer at Soft <br /> 2nd line{' '}
								</div>
							</div>
						</div>
						<Button
							sx={{
								width: '73px',
								height: '30px',
							}}
							size='small'
							variant='outlined'
						>
							{' '}
							FOLLOW
						</Button>
					</div>
				</div>
			</div>
			<Box sx={{ mt: '64px' }}>
				<Stack direction='row' justifyContent='space-between' alignItems='center'>
					<div className={styles.authors_text__title}>Recently viewed</div>
					<div className={styles.authors_text__more}>See all(5)</div>
				</Stack>
				{/*Recently viewed card*/}
				<Box sx={{ mt: '24px' }}>
					<div className={styles.view_card}>
						<Stack direction='row' justifyContent='space-between' alignItems='center'>
							<Stack spacing={0.5}>
								<div className={styles.view_card_title}>Junior Full Stack Developer</div>
								<div className={styles.view_card_company}>by EPAM UKRAINE</div>
							</Stack>
							<div className={styles.date}>Sep 12, 2022</div>
						</Stack>
					</div>
				</Box>
				<Box sx={{ mt: '24px' }}>
					<div className={styles.view_card}>
						<Stack direction='row' justifyContent='space-between' alignItems='center'>
							<Stack spacing={0.5}>
								<div className={styles.view_card_title}>Junior Full Stack Developer</div>
								<div className={styles.view_card_company}>by EPAM UKRAINE</div>
							</Stack>
							<div className={styles.date}>Sep 12, 2022</div>
						</Stack>
					</div>
				</Box>
			</Box>
		</>
	)
}
//ToDo make popular companies and tags as reusable components
