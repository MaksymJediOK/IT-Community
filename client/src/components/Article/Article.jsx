import React from 'react'
import styles from './Article.module.scss'
import { Avatar, Button, Container, Grid } from '@mui/material'
import { ArticleList } from './List/ArticleList'
import Typography from '@mui/material/Typography'

export const Article = () => {
	return (
		<Container sx={{ padding: '20px 0' }}>
			<Grid container spacing={2}>
				{/*Article List*/}
				<Grid item xs={8} paddingY='0px!important'>
					<ArticleList />
				</Grid>
				{/*Article popular*/}
				<Grid item xs={4} sx={{ marginTop: '18px' }}>
					<Typography
						variant='h5'
						align='left'
						fontFamily='Roboto ,sans-serif'
						fontSize={20}
						fontWeight={700}
						sx={{pl: '12px'}}
					>
						Popular themes
					</Typography>
					{/*Tags from API*/}
					<div className={styles.tags_container}>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Development</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Guide</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>marketing</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>startup</div>
						</div>
					</div>
					<div className={styles.authors_container}>
						<div className={styles.authors_text}>
							<div className={styles.authors_text__title}>Popular authors</div>
							<div className={styles.authors_text__more}>See more suggestions</div>
						</div>
						<div className={styles.list}>
							{/*Get Authors from API*/}
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
				</Grid>
			</Grid>
		</Container>
	)
}
