# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the rake db:seed (or created alongside the db with db:setup).
#
# Examples:
#
#   cities = City.create([{ name: 'Chicago' }, { name: 'Copenhagen' }])
#   Mayor.create(name: 'Emanuel', city: cities.first)
#

Word.transaction do
  Word.create([{name: 'word1', definition: 'the first word ever created'}, {name: 'word2', definition: 'the second word created'}])
end
